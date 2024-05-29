using Dapper;
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

    public partial class FormAddServices : Form
    {
        private AccountTourist accountTourist;

        public FormAddServices(AccountTourist accountTourist)
        {
            InitializeComponent();
            this.accountTourist = accountTourist;
            LoadGoods();
        }

        private void LoadGoods()
        {
            try
            {
                DataTable goodsTable = GoodsRoom.GetAllGoods();
                dataGridViewGoods.DataSource = goodsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading goods: " + ex.Message);
            }
        }

        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            if (dataGridViewGoods.SelectedRows.Count > 0)
            {
                try
                {
                    int goodId = (int)dataGridViewGoods.SelectedRows[0].Cells["ID"].Value;

                    // Get the current tourist room ID (this should be fetched based on the current bill or stay)
                    int touristRoomId = GetTouristRoomId(accountTourist.ID_tourist);
                    GoodsRoom.AddGoodsToRoom(touristRoomId, goodId);

                    MessageBox.Show("Goods added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding the goods: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select goods to add.");
            }
        }

        private int GetTouristRoomId(int touristId)
        {
            using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();

                // Query to retrieve the room ID associated with the tourist's current stay
                string query = @"
            SELECT tr.ID
            FROM TouristRoom tr
            INNER JOIN Bill b ON tr.BillID = b.ID
            WHERE tr.TouristID = @TouristID AND @Now BETWEEN b.Checkin AND b.Checkout";

                // Execute the query and return the room ID
                return connection.QuerySingleOrDefault<int>(query, new { TouristID = touristId, Now = DateTime.Now });
            }
        }


        private void FormAddServices_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bill bille = new Bill();
            bille.ExtendStay(accountTourist.Login, Convert.ToInt32(numericUpDown1.Value));
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            int billid = bill.GetActiveBillId(accountTourist.ID_tourist);
            bill.EmergencyCheckout(billid);
            MessageBox.Show(bill.GetCheckoutDetails(billid), "Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            accountTourist.DeleteUserCompletelyByLogin(accountTourist.Login);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
