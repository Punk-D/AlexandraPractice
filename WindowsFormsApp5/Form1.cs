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
using static WindowsFormsApp5.Program;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        AccountTourist account;
        public Form1(AccountTourist account)
        {
            InitializeComponent();
            this.account = account;
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            GetRoom newroom = new GetRoom(account);
            newroom.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormAddServices form = new FormAddServices(account);
            form.Show();
        }
    }
}
