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
    public partial class customerdetails : Form
    {
        public customerdetails()
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
            adp = new SqlDataAdapter("Select * From customer", con);
            adp.Fill(ds, "customer");
            DataTable customerTable = ds.Tables["customer"];
            dgvcustomers.DataSource = customerTable.DefaultView;
            con.Close();
        }
      
        private void tscustomer_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void customerdetails_Load(object sender, EventArgs e)
        {
            GetData();
            dgvcustomers.Columns[0].HeaderText = "customer Name";
            dgvcustomers.Columns[1].HeaderText = "Contact Person";
            dgvcustomers.Columns[2].HeaderText = "Address";
            dgvcustomers.Columns[3].HeaderText = "Phone No.";
            dgvcustomers.Columns[4].HeaderText = "Email Id";
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            customer ans = new customer();
            ans.ShowDialog();

            GetData();
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            SupName = dgvcustomers.SelectedCells[0].Value.ToString();
            rowPointer = dgvcustomers.SelectedCells[0].RowIndex;

            if (rowPointer == -1)
            {
                MessageBox.Show("Please select the customer to delete", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Are you sure to delete the record of this customer", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string DelCommand = "Delete from customer where SuppName = '" + SupName + "'";
                    SqlCommand myDelCommand = new SqlCommand(DelCommand, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        myDelCommand.Connection.Open();
                    }
                    myDelCommand.ExecuteNonQuery();
                    myDelCommand.Connection.Close();

                    MessageBox.Show("The customer details are deleted successfully", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetData();
                }
            }
        }

        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            SupName = dgvcustomers.SelectedCells[0].Value.ToString();
            SupContPerson = dgvcustomers.SelectedCells[1].Value.ToString();
            SupAddress = dgvcustomers.SelectedCells[2].Value.ToString();
            SupContactNum = dgvcustomers.SelectedCells[3].Value.ToString();
            SupEmail = dgvcustomers.SelectedCells[4].Value.ToString();
            rowPointer = dgvcustomers.SelectedCells[0].RowIndex;

            editcustomer esd = new editcustomer();
            esd.ShowDialog();

            GetData();
        }

       
    }
}
