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
    public partial class NewPurchaseOrder : Form
    {
        public NewPurchaseOrder()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sales;Integrated Security=True");
        SqlDataAdapter adp;
        DataSet ds = new DataSet();



        int COLUMN_COMBO_SELECTION = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            PrintPO.ordernumber = null;
            PrintPO.orderdate = null;
            PrintPO.supplier = null;
            PrintPO.totalamount = null;
            PrintPO.suppAddress = null;
            PrintPO.itemcode = null;
            PrintPO.quantity = null;
            PrintPO.description = null;
            PrintPO.unitvalue = null;
            PrintPO.totalvalue = null;

            if (cbSupplierName.Text == "")
            {
                MessageBox.Show("Please select a supplier", "Incomplete Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbSupplierName.Focus();
                return;
            }
            if (cbLocation.Text == "")
            {
                MessageBox.Show("Please select a truck", "Incomplete Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbLocation.Focus();
                return;
            }
            if (dgvItemDetail.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Please select an item to purchase", "Incomplete Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            adp = new SqlDataAdapter("Select * from PurchaseOrder", con);
            ds.Clear();
            adp.Fill(ds, "PurchaseOrder");
            DataTable MyTable = ds.Tables["PurchaseOrder"];
            DataRow newRow = MyTable.NewRow();
            newRow[0] = lblPONumber.Text;
            newRow[1] = cbSupplierName.Text;
            newRow[2] = lblDate.Text;
            newRow[3] = "Not Received";
            newRow[4] = lblTotalValue.Text;

            //Adding new row to the table
            MyTable.Rows.Add(newRow);

            //Generating Insert Command
            SqlCommandBuilder UpdateDataCommand = new SqlCommandBuilder(adp);
            adp.InsertCommand = UpdateDataCommand.GetInsertCommand();

            //Addding row to the dataset
            adp.Update(ds, "PurchaseOrder");

            //Updating Database with the new row
            ds.AcceptChanges();

            //--Storing in 'PODetails' Table--
            int rows;
            rows = dgvItemDetail.RowCount - 1;

            // Retrieving deatils of the PoDetails Table
            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from PODetails", con);
            DataSet ds1 = new DataSet();
            ds1.Clear();
            adp1.Fill(ds1, "PODetails");

            //creating instance of the PODetails table
            DataTable MyTable1 = ds1.Tables["PODetails"];

            for (int i = 0; i < rows; i++)
            {
                DataRow newRow1 = MyTable1.NewRow();
                newRow1[0] = lblPONumber.Text;
                newRow1[1] = cbLocation.Text;
                newRow1[2] = dgvItemDetail.Rows[i].Cells["Item"].Value;
                newRow1[3] = dgvItemDetail.Rows[i].Cells["Description"].Value;
                newRow1[4] = dgvItemDetail.Rows[i].Cells["Quantity"].Value;
                newRow1[5] = dgvItemDetail.Rows[i].Cells["UnitValue"].Value;
                newRow1[6] = dgvItemDetail.Rows[i].Cells["TotalValue"].Value;

                //Adding new row to the table
                MyTable1.Rows.Add(newRow1);

                //Generating Insert Command
                SqlCommandBuilder UpdateDataCommand1 = new SqlCommandBuilder(adp1);
                adp1.InsertCommand = UpdateDataCommand1.GetInsertCommand();

                //Addding row to the dataset
                adp1.Update(ds1, "PODetails");

                //Updating Database with the new row
                ds1.AcceptChanges();
            }
            con.Close();
            MessageBox.Show("Purchase Order Details Saved");
            DialogResult result = MessageBox.Show("Do you want to print the Purchase Form?", "Print!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PrintPO.ordernumber = lblPONumber.Text;
                PrintPO.orderdate = lblDate.Text;
                PrintPO.supplier = cbSupplierName.Text;
                PrintPO.totalamount = lblTotalValue.Text;

                SqlDataAdapter adp3 = new SqlDataAdapter("Select SuppAddress from Suppliers where SuppName = '" + cbSupplierName.Text + "'", con);
                DataSet ds3 = new DataSet();
                ds.Clear();
                adp3.Fill(ds3, "Suppliers");
                PrintPO.suppAddress = ds3.Tables["Suppliers"].Rows[0]["SuppAddress"].ToString();

                int rowcount = dgvItemDetail.RowCount;
                for (int i = 0; i < rowcount; i++)
                {
                    PrintPO.itemcode += dgvItemDetail.Rows[i].Cells["Item"].Value + Environment.NewLine;
                    PrintPO.quantity += dgvItemDetail.Rows[i].Cells["Quantity"].Value + Environment.NewLine;
                    PrintPO.description += dgvItemDetail.Rows[i].Cells["Description"].Value + Environment.NewLine;
                    PrintPO.unitvalue += dgvItemDetail.Rows[i].Cells["UnitValue"].Value + Environment.NewLine;
                    PrintPO.totalvalue += dgvItemDetail.Rows[i].Cells["TotalValue"].Value + Environment.NewLine;
                }
                PrintPO ppo = new PrintPO();
                ppo.ShowDialog();
                //Resetting the Purchase Order Form
                lblTotalValue.Text = "0";
                dgvItemDetail.Rows.Clear();
                cbLocation.SelectedIndex = -1;
                cbSupplierName.SelectedIndex = -1;
                lblPONumber.Text = PONumber();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to discard the purchase order?", "Inventory Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }     
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to reset the Purchase Order form?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lblTotalValue.Text = "0";
                dgvItemDetail.Rows.Clear();
                cbLocation.SelectedIndex = -1;
                cbSupplierName.SelectedIndex = -1;
                lblPONumber.Text = PONumber();
            }
        }

        private string PONumber()
        {
            string num = System.Guid.NewGuid().ToString();
            string newNum = "PO";
            int charCount = 0;
            foreach (char c in num)
            {
                if (char.IsDigit(c))
                {
                    newNum += c.ToString();
                    charCount += 1;
                }
                if (charCount == 4)
                {
                    break;
                }
            }
            return newNum;
        }


        private void fillSupplierName()
        {
            adp = new SqlDataAdapter("Select * from Suppliers", con);
            ds.Clear();
            adp.Fill(ds, "Suppliers");
            cbSupplierName.Items.Clear();

            foreach (DataRow dr in ds.Tables["Suppliers"].Rows)
            {
                cbSupplierName.Items.Add(dr["SuppName"]);
            }
        }

        private void filltruck()
        {
            adp = new SqlDataAdapter("Select * from truck", con);
            ds.Clear();
            adp.Fill(ds, "truck");
            cbLocation.Items.Clear();

            foreach (DataRow dr in ds.Tables["truck"].Rows)
            {
                cbLocation.Items.Add(dr["truckreg"]);
            }
        }
        private void filldriver()
        {
            adp = new SqlDataAdapter("Select * from driver", con);
            ds.Clear();
            adp.Fill(ds, "driver");
            cbLocation.Items.Clear();

            foreach (DataRow dr in ds.Tables["driver"].Rows)
            {
                cbLocation.Items.Add(dr["drivername"]);
            }
        }
        private void NewPurchaseOrder_Load(object sender, EventArgs e)
        {

            cbSupplierName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbSupplierName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbSupplierName.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbLocation.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.itemsTableAdapter.Fill(this.stockDataSet.Items);
            fillSupplierName();
            filltruck(); 
            filldriver();
            string getId = PONumber();
            lblPONumber.Text = getId;
            lblDate.Text = System.DateTime.Now.Date.ToShortDateString();

            PrintPO.ordernumber = null;
            PrintPO.orderdate = null;
            PrintPO.supplier = null;
            PrintPO.totalamount = null;
            PrintPO.suppAddress = null;
            PrintPO.itemcode = null;
            PrintPO.quantity = null;
            PrintPO.description = null;
            PrintPO.unitvalue = null;
            PrintPO.totalvalue = null;
        }

        private void dgvItemDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            if (this.dgvItemDetail.CurrentCell.ColumnIndex == COLUMN_COMBO_SELECTION)
            {
                this.dgvItemDetail.EndEdit();
            }
        }

        private void dgvItemDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == COLUMN_COMBO_SELECTION)
            {
                try
                {
                    string val = dgvItemDetail.CurrentRow.Cells[0].Value.ToString();
                    adp = new SqlDataAdapter("Select * from Items where ItemCode = '" + val + "'", con);
                    ds.Clear();
                    adp.Fill(ds, "Items");
                    dgvItemDetail.CurrentRow.Cells["Description"].Value = ds.Tables["Items"].Rows[0]["ItemDescription"].ToString();
                    dgvItemDetail.CurrentRow.Cells["UnitValue"].Value = ds.Tables["Items"].Rows[0]["ItemRate"].ToString();
                    dgvItemDetail.CurrentRow.Cells["Quantity"].Value = 1; //ds.Tables["Items"].Rows[0]["Quantity"].ToString();
                    double d1 = System.Convert.ToDouble(dgvItemDetail.CurrentRow.Cells["Quantity"].Value);
                    double d2 = System.Convert.ToDouble(dgvItemDetail.CurrentRow.Cells["UnitValue"].Value);
                    dgvItemDetail.CurrentRow.Cells["TotalValue"].Value = d1 * d2;
                    int rows;
                    rows = dgvItemDetail.RowCount;
                    double total = 0;
                    for (int i = 0; i < rows; i++)
                    {
                        total = Convert.ToDouble(dgvItemDetail.Rows[i].Cells["TotalValue"].Value) + total;
                        lblTotalValue.Text = total.ToString();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvItemDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvItemDetail.CurrentCell.OwningColumn == this.dgvItemDetail.Columns["Quantity"])
            {
                try
                {
                    double d1 = System.Convert.ToDouble(dgvItemDetail.CurrentRow.Cells["Quantity"].Value);
                    double d2 = System.Convert.ToDouble(dgvItemDetail.CurrentRow.Cells["UnitValue"].Value);
                    dgvItemDetail.CurrentRow.Cells["TotalValue"].Value = d1 * d2;
                    int rows;
                    rows = dgvItemDetail.RowCount;
                    double total = 0;
                    for (int i = 0; i < rows; i++)
                    {
                        total = Convert.ToDouble(dgvItemDetail.Rows[i].Cells["TotalValue"].Value) + total;
                        lblTotalValue.Text = total.ToString();
                    }
                }
                catch (Exception )
                {
                }
            }

            if (this.dgvItemDetail.CurrentCell.OwningColumn == this.dgvItemDetail.Columns["UnitValue"])
            {
                try
                {
                    double d1 = System.Convert.ToDouble(dgvItemDetail.CurrentRow.Cells["Quantity"].Value);
                    double d2 = System.Convert.ToDouble(dgvItemDetail.CurrentRow.Cells["UnitValue"].Value);
                    dgvItemDetail.CurrentRow.Cells["TotalValue"].Value = d1 * d2;
                    int rows;
                    rows = dgvItemDetail.RowCount;
                    double total = 0;
                    for (int i = 0; i < rows; i++)
                    {
                        total = Convert.ToDouble(dgvItemDetail.Rows[i].Cells["TotalValue"].Value) + total;
                        lblTotalValue.Text = total.ToString();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

           
        }


    

       
    }
}
