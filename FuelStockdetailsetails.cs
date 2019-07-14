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
    public partial class FuelStockdetailsetails : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=petrol_bunk_management_system;Integrated Security=True");
        DataTable dt;
        public FuelStockdetailsetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into fuelstockdetails values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert successfully");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            con.Close();
            grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from fuelstockdetails where Stock_id ='" + textBox1.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
            
            }

            dr.Close();
            con.Close();
            grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void FuelStockdetailsetails_Load(object sender, EventArgs e)
        {
            grid();
        }
        private void grid()
        {
            SqlCommand cmd = new SqlCommand("select * from fuelstockdetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "fuelstockdetails");
            dt = ds.Tables["fuelstockdetails"];
            dataGridView1.DataSource = ds.Tables["fuelstockdetails"];
            //dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
      }
    }
