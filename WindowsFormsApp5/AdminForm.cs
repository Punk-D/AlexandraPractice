using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp5.Form2;

namespace WindowsFormsApp5
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

       

        

        private void button9_Click(object sender, EventArgs e)
        {
            CheckoutTourists checkoutTourists = new CheckoutTourists();
            checkoutTourists.Show();
        }

        private void numba6_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            // Open a SaveFileDialog to ask for the file path
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb|All Files|*.*";
                saveFileDialog.Title = "Save Rooms Data As Excel File";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable roomsTable = room.GetRoomsSortedByCapacity();
                    string filePath = saveFileDialog.FileName;
                    room.ExportRoomsToExcel(roomsTable, filePath);
                    MessageBox.Show($"Rooms data exported successfully to {filePath}");
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();

            label8.Text = "Mediu : " + bill.GetAverageFinalPrice().ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            label8.Text = room.GetExpensiveAndCheapRoom();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Updatesales updatesales = new Updatesales();
            updatesales.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
