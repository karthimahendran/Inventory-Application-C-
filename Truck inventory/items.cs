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
   
    public partial class items : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sales;Integrated Security=True");
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
       
        public static int rowPointer;
        private string GenerateId()
        {
            string id = System.Guid.NewGuid().ToString();
            string newId = "ITM";
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
        public items()
        {
            InitializeComponent();
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtItemCode.Text = GenerateId();
            rtbDescription.Text = "";
            txtItemRate.Text = "";   
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rtbDescription.Text == "")
            {
                MessageBox.Show("Please provide description of the item", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtbDescription.Focus();
                return;
            }
            if (txtItemRate.Text == "")
            {
                MessageBox.Show("Please enter rate of the item", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemRate.Focus();
                return;
            }
            if (txtItemRate.Text.StartsWith("0"))
            {
                MessageBox.Show("Please enter valid rate of the item", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemRate.Focus();
                return;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            adp = new SqlDataAdapter("Select * from Items", con);
            ds.Clear();
            adp.Fill(ds, "Items");
            DataTable ItemsTable = ds.Tables["Items"];
            DataRow MyNewRow = null;
            MyNewRow = ItemsTable.NewRow();
            MyNewRow[0] = txtItemCode.Text;
            MyNewRow[1] = rtbDescription.Text;
            MyNewRow[2] = txtItemRate.Text;
            ItemsTable.Rows.Add(MyNewRow);

            SqlCommandBuilder UpdateDataCommand = new SqlCommandBuilder(adp);
            adp.InsertCommand = UpdateDataCommand.GetInsertCommand();
            adp.Update(ds, "Items");
            ds.AcceptChanges();
            MessageBox.Show("The New items details are enterd successfully", "Data Insertion Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();

            txtItemCode.Text = GenerateId();
            txtItemRate.Text = "";
            rtbDescription.Text = "";
            fillItems();
        }
        private void GetData()
        {

            ds.Clear();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            adp = new SqlDataAdapter("Select * From Items", con);
            adp.Fill(ds, "Items");
            DataTable itemTable1 = ds.Tables["Items"];
            dgvItem.DataSource = itemTable1.DefaultView;
            con.Close();
        }
      
        private void fillItems()
        {
            SqlDataAdapter adpItem = new SqlDataAdapter("Select * from Items", con);
            DataSet dsItem = new DataSet();
            dsItem.Clear();
            adpItem.Fill(dsItem, "Items");

            dgvItem.DataSource = dsItem.Tables["Items"].DefaultView;
        }
        private void items_Load(object sender, EventArgs e)
        {
            string getId = GenerateId();
            fillItems();
            //Checking if the ID already exists, 
            // If exists, regenerate it
            adp = new SqlDataAdapter("Select * from Items", con);
            ds.Clear();
            adp.Fill(ds, "Items");
            DataTable MyTable = ds.Tables["Items"];
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
            rowPointer = dgvItem.SelectedCells[0].RowIndex;
           
            // After editing, refetch the data from database, to view updated record
            GetData();
           
            btnAdd.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rtbDescription.Text == "")
            {
                MessageBox.Show("Please provide description of the item", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtbDescription.Focus();
                return;
            }
            if (txtItemRate.Text == "")
            {
                MessageBox.Show("Please enter rate of the item", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemRate.Focus();
                return;
            }
            if (txtItemRate.Text.StartsWith("0"))
            {
                MessageBox.Show("Please enter valid rate of the item", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemRate.Focus();
                return;
            }

            SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sales;Integrated Security=True");
            SqlDataAdapter adp1;
            DataSet ds1 = new DataSet();
            adp1= new SqlDataAdapter("Select * From Items", con1);
            
            adp1.Fill(ds1, "Items");
            int rowCount = ds1.Tables["Items"].Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                string lName = ds1.Tables["Items"].Rows[i][0].ToString();

                if (i == rowPointer)
                {
                    continue;
                }

                if (lName == rtbDescription.Text.Trim())
                {
                    MessageBox.Show("This items Name matches with one of the existing Items in the record" +
                    Environment.NewLine + "Please enter different Items name", "Data Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rtbDescription.Focus();
                    return;
                }
            }

            //Updating the Items table 
            SqlCommandBuilder cmdBuilder1 = null;
            cmdBuilder1 = new SqlCommandBuilder(adp1);

            con1.Open();
            ds1.Tables["Items"].Rows[rowPointer][0] = txtItemCode.Text.Trim();
            ds1.Tables["Items"].Rows[rowPointer][1] = rtbDescription.Text.Trim();
            ds1.Tables["Items"].Rows[rowPointer][2] = txtItemRate.Text.Trim();
            adp1.Update(ds1, "Items");
            ds1.AcceptChanges();
           
            MessageBox.Show("Items details edited successfully.", "Items Edit Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con1.Close();
            btnAdd.Visible = true;
            btnSave.Visible = false;
            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SupName = dgvItem.SelectedCells[0].Value.ToString();
            int rowPointer = dgvItem.SelectedCells[0].RowIndex;

            if (rowPointer == -1)
            {
                MessageBox.Show("Please select the item to delete", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Are you sure to delete the record of this item", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                try
                {
                    if (res == DialogResult.Yes)
                    {
                        string DelCommand = "Delete from Items where ItemCode = '" + SupName + "'";
                        SqlCommand myDelCommand = new SqlCommand(DelCommand, con);
                        if (con.State == ConnectionState.Closed)
                        {
                            myDelCommand.Connection.Open();
                        }
                        myDelCommand.ExecuteNonQuery();
                        myDelCommand.Connection.Close();

                        MessageBox.Show("The Items details are deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetData();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Can't be deleted");
                }
            }
        }
    }
}
