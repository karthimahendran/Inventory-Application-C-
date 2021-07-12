using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Truck_inventory
{
    public partial class Driver1 : Form
    {
        public Driver1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sales;Integrated Security=True");
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        public static int rowPointer;
        public static string LocName;
        private string GenerateId()
        {
            string id = System.Guid.NewGuid().ToString();
            string newId = "DRI";
            int charCount = 0;
            foreach (char c in id)
            {
                if (char.IsDigit(c))
                {
                    newId += c.ToString();
                    charCount += 1;
                }
                if (charCount == 4)
                {
                    break;
                }
            }
            return newId;
        }

        private void GetData()
        {

            ds.Clear();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            adp = new SqlDataAdapter("Select * From driver", con);
            adp.Fill(ds, "driver");
            DataTable itemTable1 = ds.Tables["driver"];
            dgvItem.DataSource = itemTable1.DefaultView;
            con.Close();
        }

        private void filldriver()
        {
            SqlDataAdapter adpItem = new SqlDataAdapter("Select * from driver", con);
            DataSet dsItem = new DataSet();
            dsItem.Clear();
            adpItem.Fill(dsItem, "driver");

            dgvItem.DataSource = dsItem.Tables["driver"].DefaultView;
        }
        private void ValidateInt(TextBox textBoxControl)
        {
            Regex rx = new Regex("[^0-9]");
            if (rx.IsMatch(textBoxControl.Text.Trim()))
            {
                throw new Exception("Only Numbers without decimal value are allowed in Contact Number box");
            }

        }
        private void Driver1_Load(object sender, EventArgs e)
        {
            string getId = GenerateId();
            filldriver();
            //Checking if the ID already exists, 
            // If exists, regenerate it
            adp = new SqlDataAdapter("Select * from driver", con);
            ds.Clear();
            adp.Fill(ds, "driver");
            DataTable MyTable = ds.Tables["driver"];
            for (int i = 0; i < MyTable.Rows.Count; i++)
            {
                string idExist = MyTable.Rows[i][0].ToString();
                if (getId == idExist)
                {
                    getId = GenerateId();
                    i = -1;
                }
            }
            txtItemCode.Text = getId;
            txtItemCode.ReadOnly = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (rtbDescription.Text == "")
            {
                MessageBox.Show("Please provide Driving Lisence of the driver", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtbDescription.Focus();
                return;
            }
            if (txtItemRate.Text == "")
            {
                MessageBox.Show("Please enter name of the driver", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemRate.Focus();
                return;
            }
            if (txtContactNum.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter the Contact Number", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNum.Focus();
                return;
            }
            try
            {
                ValidateInt(txtContactNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNum.Focus();
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            adp = new SqlDataAdapter("Select * from driver", con);
            ds.Clear();
            adp.Fill(ds, "driver");
            DataTable driverTable = ds.Tables["driver"];
            DataRow MyNewRow = null;
            MyNewRow = driverTable.NewRow();
            MyNewRow[0] = txtItemCode.Text;
            MyNewRow[1] = rtbDescription.Text;
            MyNewRow[2] = txtItemRate.Text;
            MyNewRow[3] = txtContactNum.Text;
            driverTable.Rows.Add(MyNewRow);

            SqlCommandBuilder UpdateDataCommand = new SqlCommandBuilder(adp);
            adp.InsertCommand = UpdateDataCommand.GetInsertCommand();
            adp.Update(ds, "driver");
            ds.AcceptChanges();
            MessageBox.Show("The New driver details are enterd successfully", "Data Insertion Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();

            txtItemCode.Text = GenerateId();
            txtItemRate.Text = "";
            rtbDescription.Text = "";
            txtContactNum.Text = "";
            filldriver();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rtbDescription.Text == "")
            {
                MessageBox.Show("Please provide Driving Lisence of the driver", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtbDescription.Focus();
                return;
            }
            if (txtItemRate.Text == "")
            {
                MessageBox.Show("Please enter name of the driver", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemRate.Focus();
                return;
            }
            if (txtContactNum.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter the Contact Number", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNum.Focus();
                return;
            }
            try
            {
                ValidateInt(txtContactNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNum.Focus();
                return;
            }
            SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sales;Integrated Security=True");
            SqlDataAdapter adp1;
            DataSet ds1 = new DataSet();
            adp1 = new SqlDataAdapter("Select * From driver", con1);

            adp1.Fill(ds1, "driver");
            int rowCount = ds1.Tables["driver"].Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                string lName = ds1.Tables["driver"].Rows[i][0].ToString();

                if (i == rowPointer)
                {
                    continue;
                }

                if (lName == rtbDescription.Text.Trim())
                {
                    MessageBox.Show("This driver Name matches with one of the existing driver in the record" +
                    Environment.NewLine + "Please enter different driver name", "Data Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rtbDescription.Focus();
                    return;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            txtItemCode.Text = GenerateId();
            rtbDescription.Text = "";
            txtItemRate.Text = "";
            txtContactNum.Text = "";
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            rowPointer = dgvItem.SelectedCells[0].RowIndex;
            LocName = dgvItem.SelectedCells[0].Value.ToString();
            if (rowPointer == -1)
            {
                MessageBox.Show("Please select the driver to delete", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Are you sure to delete this driver", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    /*   SqlDataAdapter adp1 = new SqlDataAdapter("Select * From StockInHand where LocationName = '" + LocName + "'", con);
                       DataSet ds2 = new DataSet();
                       ds2.Clear();
                       adp1.Fill(ds2, "StockInHand");
                       DataTable t1 = new DataTable();
                       t1 = ds2.Tables["StockInHand"];
                       if (t1.Rows.Count >= 1)
                       {
                           MessageBox.Show("The Location you want to delete has some stock in it." + Environment.NewLine + "Clear the stock from location and then try again", "Deleting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           return;

                       }*/

                    string DelCommand = "Delete from driver where drivercode = '" + LocName + "'";
                    SqlCommand myDelCommand = new SqlCommand(DelCommand, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        myDelCommand.Connection.Open();
                    }
                    myDelCommand.ExecuteNonQuery();
                    myDelCommand.Connection.Close();

                    MessageBox.Show("The driver deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetData();
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            if (dgvItem.SelectedCells[0].Value.ToString() == "" || dgvItem.SelectedCells[1].Value.ToString() == "" || dgvItem.SelectedCells[2].Value.ToString() == "")
            {
                MessageBox.Show("Please select the item, you want to edit", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtItemCode.Text = dgvItem.SelectedCells[0].Value.ToString();
            rtbDescription.Text = dgvItem.SelectedCells[1].Value.ToString();
            txtItemRate.Text = dgvItem.SelectedCells[2].Value.ToString();
            txtContactNum.Text = dgvItem.SelectedCells[3].Value.ToString();
            rowPointer = dgvItem.SelectedCells[0].RowIndex;

            // After editing, refetch the data from database, to view updated record
            GetData();

            btnAdd.Visible = false;
        }
    }
}