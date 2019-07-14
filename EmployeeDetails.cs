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
    public partial class EmployeeDetails : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=petrol_bunk_management_system;Integrated Security=True");
        DataTable dt;
        public EmployeeDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();                   
            SqlCommand cmd = new SqlCommand("Insert into employeedetails values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+comboBox1.Text+"','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert successfully");
            control_clear();
            con.Close();
            grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from employeedetails where Emp_code='" + textBox1.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();
                textBox7.Text = dr[7].ToString();
                textBox8.Text = dr[8].ToString();

            }
            
            dr.Close();
            con.Close();
            grid();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int a;
            int b;
            int c;
            int d;
            if (Int32.TryParse(textBox5.Text, out a) && Int32.TryParse(textBox6.Text, out b) && Int32.TryParse(textBox7.Text, out c))
            {
                d = a + c;
                textBox8.Text = (d - b).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update employeedetails set Emp_name='" + textBox2.Text + "', Address= '" + textBox3.Text + "', Gender = '" + comboBox1.Text + "', Date_of_join ='" + textBox4.Text + "',salary= '" + textBox5.Text + "',Tax= '" + textBox6.Text + "', Over_time_salery ='" + textBox7.Text + "',Net_salery= '" + textBox8.Text + "' where Emp_code = '" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("update successfully");
            control_clear();
            con.Close();
            grid();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from employeedetails where Emp_code='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete successfully");
            control_clear();
            con.Close();
            grid();

        }
        private void control_clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Count(Emp_code) + 1 from employeedetails", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text= dr[0].ToString();
            }
            dr.Close();
            con.Close();
            grid();
        }

        private void EmployeeDetails_Load(object sender, EventArgs e)
        {
            grid();
        }
        private void grid()
        {
            SqlCommand cmd = new SqlCommand("select * from employeedetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "employeedetails");
            dt = ds.Tables["employeedetails"];
            dataGridView1.DataSource = ds.Tables["employeedetails"];
            //dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
       }
    }


