using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Truck_inventory
{
    public partial class FindItem : Form
    {
        public FindItem()
        {
            InitializeComponent();
            adp = new SqlDataAdapter("Select * From StockInHand where ItemCode= '" + ItemCode + "'", con);
            ds.Clear();
            adp.Fill(ds, "StockInHand");
            if (ds.Tables[0].Rows.Count == 0)
            {
                this.WindowState = FormWindowState.Minimized;
                num = 1;
                MessageBox.Show("This item is not available in the stock");
            }
        }
        int num = 0;
        string ItemCode = main.ItemCode;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sales;Integrated Security=True");
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        private void FindItem_Load(object sender, EventArgs e)
        {
            if (num == 1)
            {
                this.Close();
            }
            string ItemCode = main.ItemCode;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sales;Integrated Security=True");
            SqlDataAdapter adp;
            DataSet ds = new DataSet();

            adp = new SqlDataAdapter("Select * From StockInHand where ItemCode= '" + ItemCode + "'", con);
            ds.Clear();
            adp.Fill(ds, "StockInHand");
            dgvItems.DataSource = ds.Tables[0].DefaultView;
            dgvItems.Columns[0].HeaderText = "Item Code";
            dgvItems.Columns[1].HeaderText = "Description";
            dgvItems.Columns[2].HeaderText = "Truck";
            dgvItems.Columns[3].HeaderText = "Rate";
            dgvItems.Columns[4].HeaderText = "Quantity";
        }
    }
}
