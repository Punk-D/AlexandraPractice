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
using static WindowsFormsApp5.Form2;

namespace WindowsFormsApp5
{
    public partial class FormRoomDetails : Form
    {
        private int roomId, userId;
        List<int> friendsList = new List<int>();

        public FormRoomDetails(int roomId, int userId)
        {
            InitializeComponent();
            this.roomId = roomId;
            this.userId = userId;
            LoadBookedDates();
        }

        private void LoadBookedDates()
        {
            try
            {
                dataGridViewBookedDates.DataSource = Bill.GetBookedDates(roomId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading booked dates: " + ex.Message);
            }
        }

        private void btnAddFriend_Click_1(object sender, EventArgs e)
        {
            string friendLogin = txtFriendLogin.Text;

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                string query = "SELECT ID_tourist FROM Accounts_Tourist WHERE Login = @Login";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", friendLogin);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int friendId = Convert.ToInt32(reader["ID_tourist"]);
                    lblFriends.Text += Environment.NewLine + friendLogin + " ";
                    friendsList.Add(friendId);
                }
                else
                {
                    MessageBox.Show("Friend not found");
                }
            }
        }

        private void btnBookRoom_Click_1(object sender, EventArgs e)
        {
            DateTime checkin = dateTimePickerCheckin.Value;
            DateTime checkout = dateTimePickerCheckout.Value;

            if (Bill.CheckDateCollision(roomId, checkin, checkout))
            {
                MessageBox.Show("Selected dates are not available.");
                return;
            }

            if (!Room.CheckRoomCapacity(roomId, friendsList.Count + 1))
            {
                MessageBox.Show("Room capacity exceeded.");
                return;
            }

            try
            {
                int billId = Bill.CreateBill(roomId, checkin, checkout, 0);

                List<int> touristIds = new List<int> { userId };
                touristIds.AddRange(friendsList);
                TouristRoom.AddTouristsToRoom(roomId, touristIds, billId);

                MessageBox.Show("Room booked successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while booking room: " + ex.Message);
            }
        }

        private void dataGridViewBookedDates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }
    }

}
