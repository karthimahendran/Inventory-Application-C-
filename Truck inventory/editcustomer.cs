using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace Truck_inventory
{
    public partial class editcustomer : Form
    {
        public editcustomer()
        {
            InitializeComponent();
        }
        private void Validate(TextBox textBoxControl)
        {
            Regex rx = new Regex("[^A-Z|^a-z|^0-9|^@|^.|^_]");
            if (rx.IsMatch(textBoxControl.Text.Trim()))
            {
                throw new Exception("Invalid E-Mail address");
            }
        }

        private void ValidateText(TextBox textBoxControl)
        {
            Regex rx = new Regex("[^A-Z|^a-z|^ |^\t]");
            if (rx.IsMatch(textBoxControl.Text.Trim()))
            {
                throw new Exception("The Contact Person Name can contain only Characters");
            }
        }

        private void ValidateInt(TextBox textBoxControl)
        {
            Regex rx = new Regex("[^0-9]");
            if (rx.IsMatch(textBoxControl.Text.Trim()))
            {
                throw new Exception("Only Numbers without decimal value are allowed in Contact Number box");
            }

        }

        private void ValidateSpecialCharacter(string str)
        {
            string txtString = str.Replace("-", "");
            Regex rx = new Regex("[^A-Z|^a-z|^0-9|^ |^\t|^,|^/]");
            if (rx.IsMatch(txtString))
            {
                throw new Exception("The address cannot contain special Characters, other than Hyphen(-), Comma (,), and Slash (/)");
            }
        }


        private void CountChar(string str)
        {
            int chrCount = 0;

            foreach (char c in str)
            {
                string chk = c.ToString();
                if (chk == "@")
                {
                    chrCount++;
                }
            }
            if (chrCount != 1)
            {
                throw new Exception("Invalid E-Mail address, due to improper use of @ symbol");
            }
        }
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (txtSuppName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter the  name", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSuppName.Focus();
                return;
            }
            if (txtContPeson.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter the Contact person name", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContPeson.Focus();
                return;
            }
            if (rtbAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter the Address", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtbAddress.Focus();
                return;
            }
            if (txtContactNum.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter the Contact Number", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNum.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please Enter the E-mail Id of the user", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            try
            {
                ValidateText(txtContPeson);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContPeson.Focus();
                return;
            }

            try
            {
                ValidateSpecialCharacter(rtbAddress.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtbAddress.Focus();
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
            try
            {
                Validate(txtEmail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            try
            {
                CountChar(txtEmail.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter adp;
            DataSet ds = new DataSet();
            adp = new SqlDataAdapter("Select * From customers", con);
            int rowPointer = customerdetails.rowPointer;
            adp.Fill(ds, "customers");
            int rowCount = ds.Tables["customers"].Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                string SName = ds.Tables["customers"].Rows[i][0].ToString();

                if (i == rowPointer)
                {
                    continue;
                }

                if (SName == txtSuppName.Text.Trim())
                {
                    MessageBox.Show("The customer with this name, already exists in our record" +
                    Environment.NewLine + "Please enter different customer name", "Data Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSuppName.Focus();
                    return;
                }
            }

            //Updating the customers table 
            SqlCommandBuilder cmdBuilder = null;
            cmdBuilder = new SqlCommandBuilder(adp);

            con.Open();
            ds.Tables["customers"].Rows[rowPointer][0] = txtSuppName.Text.Trim();
            ds.Tables["customers"].Rows[rowPointer][1] = txtContPeson.Text.Trim();
            ds.Tables["customers"].Rows[rowPointer][2] = rtbAddress.Text.Trim();
            ds.Tables["customers"].Rows[rowPointer][3] = txtContactNum.Text.Trim();
            ds.Tables["customers"].Rows[rowPointer][4] = txtEmail.Text.Trim();
            adp.Update(ds, "customers");
            ds.AcceptChanges();
            con.Close();
            this.Close();
        }

        private void editcustomer_Load(object sender, EventArgs e)
        {
            
            txtSuppName.Text = customerdetails.SupName;
            txtContPeson.Text = customerdetails.SupContPerson;
            rtbAddress.Text = customerdetails.SupAddress;
            txtContactNum.Text = customerdetails.SupContactNum;
            txtEmail.Text = customerdetails.SupEmail;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to cancel the edit?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
