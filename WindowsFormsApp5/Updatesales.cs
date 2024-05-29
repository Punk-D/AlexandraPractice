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
    public partial class Updatesales : Form
    {
        public Updatesales()
        {
            InitializeComponent();
            LoadNonCheckedOutBills();
        }

        private void LoadNonCheckedOutBills()
        {
            // Define connection string and SQL query
            string query = "SELECT * FROM Bill WHERE FinalPrice = 0";

            // Create data adapter and fill data into DataTable
            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind DataTable to DataGridView
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void UpdateSalePercent(int billId, decimal salePercent)
        {
            // Define connection string and SQL query
            string query = "UPDATE Bill SET SalePercent = @SalePercent WHERE ID = @ID";

            // Execute the SQL query to update sale percent
            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SalePercent", salePercent);
                command.Parameters.AddWithValue("@ID", billId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                // Get bill ID from selected row
                int ID = Convert.ToInt32(row.Cells["ID"].Value);

                // Get sale percent from textbox
                decimal salePercent = Convert.ToDecimal(textBox1.Text);

                // Update sale percent for the bill
                UpdateSalePercent(ID, salePercent);
            }

            // Reload DataGridView to reflect changes
            LoadNonCheckedOutBills();
        }
    }
}
