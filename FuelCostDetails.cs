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
    public partial class FuelCostDetails : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=petrol_bunk_management_system;Integrated Security=True");
        DataTable dt;
        public FuelCostDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into fuelcostdetails values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert successfully");
            control_clear();
            con.Close();
            grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from fuelcostdetails  where Serial_no='" + textBox1.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

               
                comboBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update fuelcostdetails set Fuel_type='" + comboBox1.Text + "', Liters= '" + textBox2.Text + "', Liters1 = '" + textBox3.Text + "', Liters2 ='" + textBox4.Text + "',Oil= '" + textBox5.Text + "',Oil1= '" + textBox6.Text + "', Oil2 ='" + textBox7.Text + "',Total= '" + textBox8.Text + "' where Serial_no = '" + textBox1.Text + "'", con);
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
            grid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from fuelcostdetails where Serial_no='" + textBox1.Text + "'", con);
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
            SqlCommand cmd = new SqlCommand("select Count(Serial_no) + 1 from fuelcostdetails", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
            }
            dr.Close();
            con.Close();
            grid();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int a;
            int b;
          
            if (Int32.TryParse(textBox2.Text, out a) && Int32.TryParse(textBox3.Text, out b))
            {
                textBox4.Text = (a* b ).ToString();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int a;
            int b;

            if (Int32.TryParse(textBox5.Text, out a) && Int32.TryParse(textBox6.Text, out b))
            {
                textBox7.Text = (a * b).ToString();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int a;
            int b;

            if (Int32.TryParse(textBox4.Text, out a) && Int32.TryParse(textBox7.Text, out b))
            {
                textBox8.Text = (a + b).ToString();
            }
        }

        private void FuelCostDetails_Load(object sender, EventArgs e)
        {
            grid();
        }

        private void grid()
        {
            SqlCommand cmd = new SqlCommand("select * from fuelcostdetails", con);
            SqlDataAdapter  da = new SqlDataAdapter(cmd);
            SqlCommandBuilder  cb = new SqlCommandBuilder(da);
            DataSet  ds = new DataSet();
            da.Fill(ds, "fuelcostdetails");
            dt = ds.Tables["fuelcostdetails"];
            dataGridView1.DataSource = ds.Tables["fuelcostdetails"];
            //dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
