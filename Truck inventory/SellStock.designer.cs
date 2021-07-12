namespace Truck_inventory
{
    partial class SellStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.txtQuantityAvailable = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cbItemLocation = new System.Windows.Forms.ComboBox();
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.lblQuantAvailable = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbcustomer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(271, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(143, 328);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 16;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // txtQuantityAvailable
            // 
            this.txtQuantityAvailable.Location = new System.Drawing.Point(236, 219);
            this.txtQuantityAvailable.Name = "txtQuantityAvailable";
            this.txtQuantityAvailable.ReadOnly = true;
            this.txtQuantityAvailable.Size = new System.Drawing.Size(179, 20);
            this.txtQuantityAvailable.TabIndex = 13;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(236, 176);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(179, 20);
            this.txtQuantity.TabIndex = 14;
            this.txtQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // cbItemLocation
            // 
            this.cbItemLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemLocation.FormattingEnabled = true;
            this.cbItemLocation.Location = new System.Drawing.Point(236, 124);
            this.cbItemLocation.Name = "cbItemLocation";
            this.cbItemLocation.Size = new System.Drawing.Size(179, 21);
            this.cbItemLocation.TabIndex = 11;
            this.cbItemLocation.SelectedIndexChanged += new System.EventHandler(this.cbItemLocation_SelectedIndexChanged);
            // 
            // cbItems
            // 
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(236, 78);
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size(179, 21);
            this.cbItems.TabIndex = 12;
            this.cbItems.SelectedIndexChanged += new System.EventHandler(this.cbItems_SelectedIndexChanged);
            // 
            // lblQuantAvailable
            // 
            this.lblQuantAvailable.AutoSize = true;
            this.lblQuantAvailable.Location = new System.Drawing.Point(73, 226);
            this.lblQuantAvailable.Name = "lblQuantAvailable";
            this.lblQuantAvailable.Size = new System.Drawing.Size(92, 13);
            this.lblQuantAvailable.TabIndex = 10;
            this.lblQuantAvailable.Text = "Quantity Available";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(73, 176);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(73, 124);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(35, 13);
            this.lblLocation.TabIndex = 8;
            this.lblLocation.Text = "Truck";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(73, 78);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(27, 13);
            this.lblItem.TabIndex = 7;
            this.lblItem.Text = "Item";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Customer";
            // 
            // cbcustomer
            // 
            this.cbcustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcustomer.FormattingEnabled = true;
            this.cbcustomer.Location = new System.Drawing.Point(236, 272);
            this.cbcustomer.Name = "cbcustomer";
            this.cbcustomer.Size = new System.Drawing.Size(179, 21);
            this.cbcustomer.TabIndex = 18;
            // 
            // SellStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 376);
            this.Controls.Add(this.cbcustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.txtQuantityAvailable);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.cbItemLocation);
            this.Controls.Add(this.cbItems);
            this.Controls.Add(this.lblQuantAvailable);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblItem);
            this.Name = "SellStock";
            this.Text = "SellStock";
            this.Load += new System.EventHandler(this.SellStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.TextBox txtQuantityAvailable;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cbItemLocation;
        private System.Windows.Forms.ComboBox cbItems;
        private System.Windows.Forms.Label lblQuantAvailable;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbcustomer;
    }
}