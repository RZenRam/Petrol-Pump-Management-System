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
    public partial class DebtorDetails : Form
    {

        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=petrol_bunk_management_system;Integrated Security=True");
        DataTable dt;

        public DebtorDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into debtordetails values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert successfully");
            control_clear();
            con.Close();
            grid();
        }

       
        private void control_clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            grid();
          
        }

    
        
        private void button2_Click_1(object sender, EventArgs e)
        {
             con.Open();
            SqlCommand cmd = new SqlCommand("select*from debtordetails where serial_no ='" + textBox1.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                comboBox1.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();
                textBox7.Text = dr[7].ToString();
             
            }

            dr.Close();
            con.Close();
            grid();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update debtordetails set Name='" + textBox2.Text + "', Address= '" + textBox3.Text + "',Amount = '" + textBox4.Text + "',Mode ='" + comboBox1.Text + "',Period_date = '" + textBox5.Text + "',Phone_no= '" + textBox6.Text + "',vehicle_no ='" + textBox7.Text + "' where serial_no = '" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("update successfully");
            control_clear();
            con.Close();
            grid();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from debtordetails where serial_no ='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete successfully");
            control_clear();
            con.Close();
            grid();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Count(serial_no ) + 1 from debtordetails", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
            }
            dr.Close();
            con.Close();
        }

        private void DebtorDetails_Load(object sender, EventArgs e)
        {
            grid();
        }
        private void grid()
        {
            SqlCommand cmd = new SqlCommand("select * from debtordetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "debtordetails");
            dt = ds.Tables["debtordetails"];
            dataGridView1.DataSource = ds.Tables["debtordetails"];
            //dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
      
    }
}
