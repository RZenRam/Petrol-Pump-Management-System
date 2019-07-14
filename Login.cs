using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Petrol_Bunk_Management_System
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=GEETHU-FB0ECB23\\SQLEXPRESS; Initial Catalog=petrol_bunk_management_system;Integrated Security=true");
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                MDIForm MDI = new MDIForm();
                MDI.Show();
                textBox1.Text = "";
                textBox2.Text = "";

            }
            else
            {
                MessageBox.Show("Invalid username and password ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
