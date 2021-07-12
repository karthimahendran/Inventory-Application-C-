using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Truck_inventory
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sales;Integrated Security=True");
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        public static string ItemCode;

        

        public void fillItems()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select ItemCode from Items", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Items");
            cbFindItem.Items.Clear();
            foreach (DataRow dr in ds.Tables["Items"].Rows)
            {
                cbFindItem.Items.Add(dr["ItemCode"]);
            }
        }

        
        private void invetoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items it = new items();
            it.ShowDialog();
           
            fillItems();
            it.BringToFront();
        }

        private void newTruckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            truck it = new truck();
            it.ShowDialog();
            it.BringToFront();
           
            fillItems();
        }

        private void newSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supplier it = new supplier();
            it.ShowDialog();
            it.BringToFront();
            
            fillItems();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Driver1 it = new Driver1();
            it.ShowDialog();
            it.BringToFront();
           
            fillItems();
        }

        private void OpenSuppliersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supplierdetails it = new supplierdetails();
            it.ShowDialog();
            it.BringToFront();
            
            fillItems();
        }   

        private void openCustomerlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerdetails it = new customerdetails();
            it.ShowDialog();
            it.BringToFront();
            
            fillItems();
        }

        private void orderStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPurchaseOrder nps = new NewPurchaseOrder();
            nps.ShowDialog();
            
            fillItems();
         
        }

        private void receiveStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiveStock rs = new ReceiveStock();
            do
            {
                rs.ShowDialog();
                
               
            }
            while (ReceiveStock.act == "Receive");
        }

        private void sellStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellStock ss = new SellStock();
            do
            {
                ss.ShowDialog();
               
             }
            while (SellStock.act == "Sell");       
        }

        

        private void exitCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {ItemReport ir = new ItemReport();
            ir.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PurchaseOrderReport pod = new PurchaseOrderReport();
            pod.ShowDialog();
        }

        private void stockTransactionReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            StockTransactionsReport str = new StockTransactionsReport();
            str.ShowDialog();
        }

        private void main_Load(object sender, EventArgs e)
        {
            
            fillItems();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cbFindItem.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to find");
                return;
            }
            ItemCode = cbFindItem.Text;
            FindItem fi = new FindItem();
            fi.ShowDialog();
            cbFindItem.Text = "";
           
            fillItems();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            customer it = new customer();
            it.ShowDialog();
            it.BringToFront();

            fillItems();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            customerdetails it = new customerdetails();
            it.ShowDialog();
            it.BringToFront();

            fillItems();
        }

  

       
    }
}
