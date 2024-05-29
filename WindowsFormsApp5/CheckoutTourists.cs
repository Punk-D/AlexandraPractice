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
    public partial class CheckoutTourists : Form
    {
        public CheckoutTourists()
        {
            InitializeComponent();
            Tourist tourist = new Tourist();

            dataGridView1.DataSource = tourist.GetTouristsEndingVacationOn(dateTimePicker1.Value);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Tourist tourist = new Tourist();
            dataGridView1.DataSource = tourist.GetTouristsEndingVacationOn(dateTimePicker1.Value);
        }
    }
}
