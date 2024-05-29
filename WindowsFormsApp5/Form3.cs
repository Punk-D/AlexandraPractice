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
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();

        }

        private void Register_Click(object sender, EventArgs e)
        {
            string password;
            if (pass.Text != repass.Text)
            {
                label2.Text = "Passwords do not match";
                return;
            }
            password = BCrypt.Net.BCrypt.HashPassword(pass.Text);
            Tourist newtourist = new Tourist();
            newtourist.Register(log.Text, password, nam.Text, sur.Text);
            MessageBox.Show("Registration completed", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult end = MessageBox.Show("Proceed to login?", "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (end == DialogResult.Yes) { this.Hide(); }
        }
    }
}
