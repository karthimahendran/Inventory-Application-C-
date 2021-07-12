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
    public partial class supplierdetails : Form
    {
        public supplierdetails()
        {
            InitializeComponent();
        }
        public static string SupName, SupContPerson, SupAddress, SupContactNum, SupEmail = null;
        public static int rowPointer;

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sales;Integrated Security=True");
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        private void GetData()
        {

            ds.Clear();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            adp = new SqlDataAdapter("Select * From Suppliers", con);
            adp.Fill(ds, "Suppliers");
            DataTable SupplierTable = ds.Tables["Suppliers"];
            dgvSuppliers.DataSource = SupplierTable.DefaultView;
            con.Close();
        }
     

       
        private void supplierdetails_Load(object sender, EventArgs e)
        {
            GetData();
            dgvSuppliers.Columns[0].HeaderText = "Supplier Name";
            dgvSuppliers.Columns[1].HeaderText = "Contact Person";
            dgvSuppliers.Columns[2].HeaderText = "Address";
            dgvSuppliers.Columns[3].HeaderText = "Phone No.";
            dgvSuppliers.Columns[4].HeaderText = "Email Id";
        }

        private void toolStripDelete_Click_1(object sender, EventArgs e)
        {
            SupName = dgvSuppliers.SelectedCells[0].Value.ToString();
            rowPointer = dgvSuppliers.SelectedCells[0].RowIndex;

            if (rowPointer == -1)
            {
                MessageBox.Show("Please select the supplier to delete", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Are you sure to delete the record of this supplier", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string DelCommand = "Delete from Suppliers where SuppName = '" + SupName + "'";
                    SqlCommand myDelCommand = new SqlCommand(DelCommand, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        myDelCommand.Connection.Open();
                    }
                    myDelCommand.ExecuteNonQuery();
                    myDelCommand.Connection.Close();

                    MessageBox.Show("The Supplier details are deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetData();
                }
            }
        }

        private void toolStripEdit_Click_1(object sender, EventArgs e)
        {
             SupName = dgvSuppliers.SelectedCells[0].Value.ToString();
            SupContPerson = dgvSuppliers.SelectedCells[1].Value.ToString();
            SupAddress = dgvSuppliers.SelectedCells[2].Value.ToString();
            SupContactNum = dgvSuppliers.SelectedCells[3].Value.ToString();
            SupEmail = dgvSuppliers.SelectedCells[4].Value.ToString();
            rowPointer = dgvSuppliers.SelectedCells[0].RowIndex;

            editsupplier esd = new editsupplier();
            esd.ShowDialog();

            GetData();
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            supplier ans = new supplier();
            ans.ShowDialog();

            GetData();
        }
    }
}
