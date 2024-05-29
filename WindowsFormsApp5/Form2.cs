using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using BCrypt.Net;
using static WindowsFormsApp5.Program;
using ClosedXML.Excel;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        public static class DatabaseConfig
        {
            public static string ConnectionString { get; set; } = "Server=(localdb)\\MSSQLLocalDB;Database=hotel;Integrated Security=true;";
        }
        public class Room
        {
            public int RoomID { get; set; }
            public int Capacity { get; set; }
            public decimal Price { get; set; }

            public static IEnumerable<Room> GetAll()
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    return connection.Query<Room>("SELECT * FROM Room");
                }
            }
            public void ExportRoomsToExcel(DataTable roomsDataTable, string filePath)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Rooms");

                    // Insert DataTable content into the worksheet
                    worksheet.Cell(1, 1).InsertTable(roomsDataTable);

                    // Save the workbook to the specified path
                    workbook.SaveAs(filePath);
                }
            }
            public string GetExpensiveAndCheapRoom()
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    // Query to get the most expensive room
                    string expensiveQuery = @"
                SELECT TOP 1 RoomID, Capacity, Price
                FROM Room
                ORDER BY Price DESC";

                    var expensiveRoom = connection.QuerySingleOrDefault<Room>(expensiveQuery);

                    // Query to get the cheapest room
                    string cheapQuery = @"
                SELECT TOP 1 RoomID, Capacity, Price
                FROM Room
                ORDER BY Price ASC";

                    var cheapRoom = connection.QuerySingleOrDefault<Room>(cheapQuery);

                    // Format the results into a string
                    string result = $"Expensive: RoomID: {expensiveRoom.RoomID}, Capacity: {expensiveRoom.Capacity}, Price: {expensiveRoom.Price:C}\n" +
                                    $"Cheap: RoomID: {cheapRoom.RoomID}, Capacity: {cheapRoom.Capacity}, Price: {cheapRoom.Price:C}";

                    return result;
                }
            }
            public DataTable GetRoomsSortedByCapacity()
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    string query = @"
            SELECT RoomID, Capacity, Price
            FROM Room
            ORDER BY Capacity";

                    var roomsDataTable = new DataTable();

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(roomsDataTable);
                        }
                    }

                    return roomsDataTable;
                }
            }

            public static Room GetById(int id)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    return connection.QuerySingleOrDefault<Room>("SELECT * FROM Room WHERE RoomID = @Id", new { Id = id });
                }
            }
            public static bool CheckRoomCapacity(int roomId, int numberOfFriends)
            {
                Room room = GetById(roomId);
                return room != null && numberOfFriends <= room.Capacity;
            }
        }
        public class Tourist
        {
            public int TouristID { get; set; }
            public string TouristName { get; set; }
            public string TouristSurname { get; set; }

            public void Register(string login, string password, string name, string surname)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    var existingAccount = connection.QuerySingleOrDefault<AccountTourist>(
                        "SELECT * FROM Accounts_Tourist WHERE Login = @Login", new { Login = login });

                    if (existingAccount != null)
                    {
                        throw new Exception("Login not unique");
                    }

                    var touristId = connection.QuerySingle<int>(
                        "INSERT INTO tourist (TouristName, TouristSurname) OUTPUT INSERTED.TouristID VALUES (@Name, @Surname);",
                        new { Name = name, Surname = surname });

                    connection.Execute(
                        "INSERT INTO Accounts_Tourist (Login, Password, ID_tourist) VALUES (@Login, @Password, @TouristId);",
                        new { Login = login, Password = password, TouristId = touristId });
                }
            }
            public DataTable GetTouristsEndingVacationOn(DateTime date)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    string query = @"
            SELECT t.TouristID, t.TouristName, t.TouristSurname, b.Checkout
            FROM tourist t
            INNER JOIN TouristRoom tr ON t.TouristID = tr.TouristID
            INNER JOIN Bill b ON tr.BillID = b.ID
            WHERE CAST(b.Checkout AS DATE) = @Date";

                    var touristsDataTable = new DataTable();

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Date", date.Date);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(touristsDataTable);
                        }
                    }

                    return touristsDataTable;
                }
            }
        }
        public class AccountTourist
        {
            public int ID { get; set; }
            public string Login { get; set; }
            public int ID_tourist { get; set; }
            public string Password { get; set; }

            public static AccountTourist GetByLogin(string login)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    return connection.QuerySingleOrDefault<AccountTourist>(
                        "SELECT * FROM Accounts_Tourist WHERE Login = @Login", new { Login = login });
                }
            }

            public static Tourist GetTouristByLogin(string login)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    return connection.QuerySingleOrDefault<Tourist>(
                        "SELECT t.* FROM tourist t INNER JOIN Accounts_Tourist a ON t.TouristID = a.ID_tourist WHERE a.Login = @Login",
                        new { Login = login });
                }

            }
            public void DeleteUserCompletelyByLogin(string login)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    // Start a transaction to ensure all deletions are atomic
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Retrieve the TouristID associated with the account
                            var touristId = connection.QuerySingle<int>(
                                @"SELECT ID_tourist 
                      FROM Accounts_Tourist 
                      WHERE Login = @Login",
                                new { Login = login },
                                transaction: transaction);

                            // Delete the Account record first to satisfy the foreign key constraint
                            connection.Execute(
                                "DELETE FROM Accounts_Tourist WHERE Login = @Login",
                                new { Login = login },
                                transaction: transaction);

                            // Delete associated records from GoodsRooms
                            connection.Execute(
                                @"DELETE gr 
                      FROM GoodsRooms gr
                      INNER JOIN TouristRoom tr ON gr.TouristRoomID = tr.ID
                      WHERE tr.TouristID = @TouristID",
                                new { TouristID = touristId },
                                transaction: transaction);

                            // Delete associated records from TouristRoom
                            connection.Execute(
                                "DELETE FROM TouristRoom WHERE TouristID = @TouristID",
                                new { TouristID = touristId },
                                transaction: transaction);

                            // Delete the Tourist record
                            connection.Execute(
                                "DELETE FROM tourist WHERE TouristID = @TouristID",
                                new { TouristID = touristId },
                                transaction: transaction);

                            // Commit the transaction
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction in case of an error
                            transaction.Rollback();
                            throw new Exception("An error occurred while deleting the user", ex);
                        }
                    }
                }
            }

        }
        public static class GoodsRoom
        {
            public static void AddGoodsToRoom(int touristRoomId, int goodId)
            {
                string query = "INSERT INTO GoodsRooms (GoodID, TouristRoomID) VALUES (@GoodID, @TouristRoomID)";

                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GoodID", goodId);
                    command.Parameters.AddWithValue("@TouristRoomID", touristRoomId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public static DataTable GetAllGoods()
            {
                string query = "SELECT ID, Name, Price FROM Goods";

                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable goodsTable = new DataTable();
                        goodsTable.Load(reader);
                        return goodsTable;
                    }
                }
            }
        }

        public class Good
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public static IEnumerable<Good> GetAll()
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    return connection.Query<Good>("SELECT * FROM Goods");
                }
            }
        }
        public class Bill
        {
            public int ID { get; set; }
            public DateTime Checkin { get; set; }
            public DateTime Checkout { get; set; }
            public int SalePercent { get; set; }
            public decimal FinalPrice { get; set; }
            public int RoomID { get; set; }
            public decimal GetAverageFinalPrice()
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT AVG(FinalPrice) AS AverageFinalPrice
                FROM Bill
                WHERE FinalPrice IS NOT NULL";

                    var command = new SqlCommand(query, connection);
                    var result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        throw new InvalidOperationException("No final prices found.");
                    }
                }
            }
            public Bill CalculateBill(int billId)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    // Execute the CalculateBill stored procedure
                    var result = connection.QuerySingleOrDefault<Bill>(
                        "CalculateBill",
                        new { BillID = billId },
                        commandType: CommandType.StoredProcedure);

                    return result;
                }
            }

            public string GetCheckoutDetails(int billId)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    string query = @"
            SELECT 
                r.RoomID,
                r.Price AS RoomPrice,
                b.SalePercent,
                DATEDIFF(day, b.Checkin, b.Checkout) + 1 AS DaysStayed,
                (r.Price * (100 - b.SalePercent) / 100) AS RoomPriceWithSale,
                ISNULL(SUM(g.Price), 0) AS GoodsTotalCost,
                ((r.Price * (100 - b.SalePercent) / 100) * (DATEDIFF(day, b.Checkin, b.Checkout) + 1)) + ISNULL(SUM(g.Price), 0) AS FinalSum
            FROM 
                Bill b
            INNER JOIN 
                TouristRoom tr ON b.RoomID = tr.RoomID
            INNER JOIN 
                Room r ON tr.RoomID = r.RoomID
            LEFT JOIN 
                GoodsRooms gr ON tr.ID = gr.TouristRoomID
            LEFT JOIN 
                Goods g ON gr.GoodID = g.ID
            WHERE 
                b.ID = @BillID
            GROUP BY
                r.RoomID,
                r.Price,
                b.SalePercent,
                b.Checkin,
                b.Checkout";

                    var result = connection.QuerySingleOrDefault(query, new { BillID = billId });

                    string checkoutDetails = $"Room Number: {result.RoomID}\n" +
                                             $"Room Price: {result.RoomPrice}\n" +
                                             $"Price for Room with Sale Considered: {result.RoomPriceWithSale}\n" +
                                             $"Number of Days Stayed: {result.DaysStayed}\n" +
                                             $"Total Price for Stayed Days with Sale: {result.FinalSum}\n" +
                                             $"Goods Total Cost: {result.GoodsTotalCost}\n" +
                                             $"Final Sum: {result.FinalSum}";

                    return checkoutDetails;
                }
            }
            public void EmergencyCheckout(int billId)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    // Update the checkout date to today
                    connection.Execute(
                        "UPDATE Bill SET Checkout = GETDATE() WHERE ID = @BillID",
                        new { BillID = billId });

                    // Execute the stored procedure to calculate the bill with the updated checkout date
                    CalculateBill(billId);
                }
            }
            public static bool CheckDateCollision(int roomId, DateTime checkin, DateTime checkout)
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Bill 
            WHERE RoomID = @RoomID 
            AND ((Checkin < @Checkout AND Checkout > @Checkin))";

                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RoomID", roomId);
                    command.Parameters.AddWithValue("@Checkin", checkin);
                    command.Parameters.AddWithValue("@Checkout", checkout);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }

            public static int CreateBill(int roomId, DateTime checkin, DateTime checkout, int salePercent)
            {
                string query = "INSERT INTO Bill (RoomID, Checkin, Checkout, SalePercent, FinalPrice) OUTPUT INSERTED.ID VALUES (@RoomID, @Checkin, @Checkout, @SalePercent, 0)";

                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RoomID", roomId);
                    command.Parameters.AddWithValue("@Checkin", checkin);
                    command.Parameters.AddWithValue("@Checkout", checkout);
                    command.Parameters.AddWithValue("@SalePercent", salePercent);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }

            public static DataTable GetBookedDates(int roomId)
            {
                string query = @"
            SELECT Checkin, Checkout 
            FROM Bill 
            WHERE RoomID = @RoomID";

                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RoomID", roomId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable bookedDatesTable = new DataTable();
                        bookedDatesTable.Load(reader);
                        return bookedDatesTable;
                    }
                }
            }

            public void ExtendStay(string login, int additionalDays)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    // Get the tourist ID based on the login
                    int touristId = connection.QuerySingleOrDefault<int>(
                        "SELECT ID_tourist FROM Accounts_Tourist WHERE Login = @Login",
                        new { Login = login });

                    // Get the current check-in and check-out dates for the tourist's stay
                    var currentStay = connection.QuerySingleOrDefault<(DateTime Checkin, DateTime Checkout)>(
                        @"SELECT b.Checkin, b.Checkout
              FROM Bill b
              JOIN TouristRoom tr ON b.ID = tr.BillID
              WHERE tr.TouristID = @TouristID AND @Now BETWEEN b.Checkin AND b.Checkout",
                        new { TouristID = touristId, Now = DateTime.Now });

                    if (currentStay == default)
                    {
                        throw new Exception("No current stay found for the given login");
                    }

                    // Calculate the new check-out date
                    DateTime newCheckout = currentStay.Checkout.AddDays(additionalDays);

                    // Check for collisions with existing bookings for the room
                    bool hasCollision = connection.ExecuteScalar<bool>(
                        @"SELECT COUNT(*)
              FROM Bill b
              JOIN TouristRoom tr ON b.ID = tr.BillID
              WHERE tr.RoomID = (SELECT RoomID FROM TouristRoom WHERE TouristID = @TouristID) 
              AND @NewCheckin < b.Checkout AND b.Checkin < @NewCheckout",
                        new { TouristID = touristId, NewCheckin = currentStay.Checkout, NewCheckout = newCheckout });

                    if (hasCollision)
                    {
                        throw new Exception("Cannot extend stay due to booking collision");
                    }

                    // Update the check-out date for the current stay
                    connection.Execute(
                        "UPDATE Bill SET Checkout = @NewCheckout WHERE ID = (SELECT BillID FROM TouristRoom WHERE TouristID = @TouristID)",
                        new { NewCheckout = newCheckout, TouristID = touristId });
                    MessageBox.Show("Extended successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            public int GetActiveBillId(int touristId)
            {
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    // Query to retrieve the active bill ID for the given tourist ID
                    string query = @"
            SELECT b.ID
            FROM Bill b
            INNER JOIN TouristRoom tr ON b.RoomID = tr.RoomID
            WHERE tr.TouristID = @TouristID AND @Now BETWEEN b.Checkin AND b.Checkout";

                    // Execute the query and return the active bill ID
                    return connection.QuerySingleOrDefault<int>(query, new { TouristID = touristId, Now = DateTime.Now });
                }
            }

        }
        public Form2()
        {
            InitializeComponent();
            var label = new Label()
            {
                Height = 2,
                Dock = DockStyle.Bottom,
                BackColor = Color.Red
            };
            Login.Controls.Add(label);
            var label1 = new Label()
            {
                Height = 2,
                Dock = DockStyle.Bottom,
                BackColor = Color.Red
            };
            Password.Controls.Add(label1);
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Hide_Click(object sender, EventArgs e)
        {
            Password.UseSystemPasswordChar = true;
            Hide.Visible = false;
            Show.Visible = true;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            Password.UseSystemPasswordChar = false;
            Hide.Visible = true;
            Show.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        public class TouristRoom
        {
            public int ID { get; set; }
            public int RoomID { get; set; }
            public int TouristID { get; set; }
            public int BillID { get; set; }

            public static void AddTouristsToRoom(int roomId, List<int> touristIds, int billId)
            {
                string query = "INSERT INTO TouristRoom (RoomID, TouristID, BillID) VALUES (@RoomID, @TouristID, @BillID)";

                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    foreach (int touristId in touristIds)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@RoomID", roomId);
                            command.Parameters.AddWithValue("@TouristID", touristId);
                            command.Parameters.AddWithValue("@BillID", billId);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void Createacc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form3 loginform = new Form3();
            loginform.ShowDialog();
            this.Show();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            string login = Login.Text;
            string password = Password.Text;
            if (login == "Alexandra"&&password=="Rotaru")
            {
                AdminForm form = new AdminForm();
                this.Hide();
                form.ShowDialog();
                this.Close();
                
                
            }

            try
            {
                var account = AccountTourist.GetByLogin(login);

                if (account == null)
                {
                    label2.Text = "Login not found.";
                    return;
                }

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, account.Password);

                if (!isPasswordValid)
                {
                    label2.Text = "Incorrect password.";
                    return;
                }

                // Login successful, proceed with the next steps (e.g., open the main form)

                
                this.Hide();
                Form1 form1 = new Form1(account);
                form1.FormClosed += (s, args) => this.Close();
                form1.ShowDialog();
                // Open the main form or perform other actions
            }
            catch (Exception ex)
            {
                label2.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}
//