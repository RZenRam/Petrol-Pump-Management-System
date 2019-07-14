using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Petrol_Bunk_Management_System
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }

        private void employeeDetailscsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeDetails emp = new EmployeeDetails();
            emp.Show();
        }

        private void fuelCostDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuelCostDetails fuel = new FuelCostDetails();
            fuel.Show();

        }

        private void debtorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebtorDetails debut = new DebtorDetails();
            debut.Show();

        }

        private void purchaseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseDetails pur = new PurchaseDetails();
            pur.Show();
        }

        private void salesDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesDetails sales = new SalesDetails();
            sales.Show();

        }

        private void fuelStockdetailsetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuelStockdetailsetails fuelstock = new FuelStockdetailsetails();
            fuelstock.Show();

        }

     

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee_Details_Report em = new Employee_Details_Report();
            em.Show();
        }

        private void fuelCostDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FuelCostReport fuel = new FuelCostReport();
            fuel.Show();

        }

        private void debtorDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Debtor_Details_Report d = new Debtor_Details_Report();
            d.Show();
        }

        private void purchaseDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PurchaseReport pur = new PurchaseReport();
            pur.Show();

        }

        private void salesDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SalesReport sal = new SalesReport();
            sal.Show();

        }

        private void fuelStockdetailsetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FuelStockReport fu = new FuelStockReport();
            fu.Show();
            

        }

        private void mASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
