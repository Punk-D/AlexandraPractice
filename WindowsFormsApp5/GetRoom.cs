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
    public partial class GetRoom : Form
    {
        SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString);
        private void InitializeRooms()
        {
            string query = "SELECT * FROM Room";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable roomsTable = new DataTable();
                roomsTable.Load(reader);
                dataGridViewRooms.DataSource = roomsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading rooms: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private AccountTourist account;
        public GetRoom(AccountTourist account)
        {
            InitializeComponent();
            InitializeRooms();
            this.account = account;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int roomId = Convert.ToInt32(dataGridViewRooms.Rows[e.RowIndex].Cells["RoomID"].Value);
            FormRoomDetails formRoomDetails = new FormRoomDetails(roomId, account.ID_tourist);
            formRoomDetails.Show();
        }

        private void af_Click(object sender, EventArgs e)
        {

        }

        private void GetRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
