namespace Truck_inventory
{
    partial class main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiveStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTruckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSuppliersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.stockTransactionReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbFindItem = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.cbFindItem = new System.Windows.Forms.ComboBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gbFindItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryToolStripMenuItem,
            this.truckToolStripMenuItem,
            this.suppliersToolStripMenuItem,
            this.toolStripMenuItem1,
            this.customerToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1362, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItemToolStripMenuItem,
            this.orderStockToolStripMenuItem,
            this.receiveStockToolStripMenuItem,
            this.sellStockToolStripMenuItem,
            this.exitCloseToolStripMenuItem});
            this.inventoryToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // newItemToolStripMenuItem
            // 
            this.newItemToolStripMenuItem.Name = "newItemToolStripMenuItem";
            this.newItemToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.newItemToolStripMenuItem.Text = "New Item........";
            this.newItemToolStripMenuItem.Click += new System.EventHandler(this.newItemToolStripMenuItem_Click);
            // 
            // orderStockToolStripMenuItem
            // 
            this.orderStockToolStripMenuItem.Name = "orderStockToolStripMenuItem";
            this.orderStockToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.orderStockToolStripMenuItem.Text = "Purchase Stock";
            this.orderStockToolStripMenuItem.Click += new System.EventHandler(this.orderStockToolStripMenuItem_Click);
            // 
            // receiveStockToolStripMenuItem
            // 
            this.receiveStockToolStripMenuItem.Name = "receiveStockToolStripMenuItem";
            this.receiveStockToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.receiveStockToolStripMenuItem.Text = "Receive Stock";
            this.receiveStockToolStripMenuItem.Click += new System.EventHandler(this.receiveStockToolStripMenuItem_Click);
            // 
            // sellStockToolStripMenuItem
            // 
            this.sellStockToolStripMenuItem.Name = "sellStockToolStripMenuItem";
            this.sellStockToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.sellStockToolStripMenuItem.Text = "Sell Stock";
            this.sellStockToolStripMenuItem.Click += new System.EventHandler(this.sellStockToolStripMenuItem_Click);
            // 
            // exitCloseToolStripMenuItem
            // 
            this.exitCloseToolStripMenuItem.Name = "exitCloseToolStripMenuItem";
            this.exitCloseToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.exitCloseToolStripMenuItem.Text = "Exit (Close)";
            this.exitCloseToolStripMenuItem.Click += new System.EventHandler(this.exitCloseToolStripMenuItem_Click);
            // 
            // truckToolStripMenuItem
            // 
            this.truckToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTruckToolStripMenuItem});
            this.truckToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truckToolStripMenuItem.Name = "truckToolStripMenuItem";
            this.truckToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.truckToolStripMenuItem.Text = "Truck";
            // 
            // newTruckToolStripMenuItem
            // 
            this.newTruckToolStripMenuItem.Name = "newTruckToolStripMenuItem";
            this.newTruckToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.newTruckToolStripMenuItem.Text = "New Truck";
            this.newTruckToolStripMenuItem.Click += new System.EventHandler(this.newTruckToolStripMenuItem_Click);
            // 
            // suppliersToolStripMenuItem
            // 
            this.suppliersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSupplierToolStripMenuItem,
            this.OpenSuppliersListToolStripMenuItem});
            this.suppliersToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.suppliersToolStripMenuItem.Text = "Suppliers";
            // 
            // newSupplierToolStripMenuItem
            // 
            this.newSupplierToolStripMenuItem.Name = "newSupplierToolStripMenuItem";
            this.newSupplierToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.newSupplierToolStripMenuItem.Text = "New Supplier";
            this.newSupplierToolStripMenuItem.Click += new System.EventHandler(this.newSupplierToolStripMenuItem_Click);
            // 
            // OpenSuppliersListToolStripMenuItem
            // 
            this.OpenSuppliersListToolStripMenuItem.Name = "OpenSuppliersListToolStripMenuItem";
            this.OpenSuppliersListToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.OpenSuppliersListToolStripMenuItem.Text = "Open Suppliers list";
            this.OpenSuppliersListToolStripMenuItem.Click += new System.EventHandler(this.OpenSuppliersListToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCustomerToolStripMenuItem});
            this.customerToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.customerToolStripMenuItem.Text = "Driver";
            // 
            // newCustomerToolStripMenuItem
            // 
            this.newCustomerToolStripMenuItem.Name = "newCustomerToolStripMenuItem";
            this.newCustomerToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.newCustomerToolStripMenuItem.Text = "New Driver";
            this.newCustomerToolStripMenuItem.Click += new System.EventHandler(this.newCustomerToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.stockTransactionReportToolStripMenuItem1});
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(259, 24);
            this.toolStripMenuItem2.Text = "Invetory Report";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(259, 24);
            this.toolStripMenuItem3.Text = "Purchase Order Report";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // stockTransactionReportToolStripMenuItem1
            // 
            this.stockTransactionReportToolStripMenuItem1.Name = "stockTransactionReportToolStripMenuItem1";
            this.stockTransactionReportToolStripMenuItem1.Size = new System.Drawing.Size(259, 24);
            this.stockTransactionReportToolStripMenuItem1.Text = "Stock Transaction Report";
            this.stockTransactionReportToolStripMenuItem1.Click += new System.EventHandler(this.stockTransactionReportToolStripMenuItem1_Click);
            // 
            // gbFindItem
            // 
            this.gbFindItem.BackColor = System.Drawing.Color.DarkOrange;
            this.gbFindItem.Controls.Add(this.btnFind);
            this.gbFindItem.Controls.Add(this.cbFindItem);
            this.gbFindItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gbFindItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbFindItem.Location = new System.Drawing.Point(10, 221);
            this.gbFindItem.Name = "gbFindItem";
            this.gbFindItem.Size = new System.Drawing.Size(165, 185);
            this.gbFindItem.TabIndex = 15;
            this.gbFindItem.TabStop = false;
            this.gbFindItem.Text = "Find Item";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(46, 104);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 31);
            this.btnFind.TabIndex = 14;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cbFindItem
            // 
            this.cbFindItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFindItem.FormattingEnabled = true;
            this.cbFindItem.Location = new System.Drawing.Point(6, 54);
            this.cbFindItem.Name = "cbFindItem";
            this.cbFindItem.Size = new System.Drawing.Size(153, 23);
            this.cbFindItem.TabIndex = 13;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(98, 24);
            this.toolStripMenuItem1.Text = "Customers";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(221, 24);
            this.toolStripMenuItem4.Text = "New Customer";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(221, 24);
            this.toolStripMenuItem5.Text = "Open Customers list";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.gbFindItem);
            this.Controls.Add(this.menuStrip1);
            this.Name = "main";
            this.Text = "main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbFindItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiveStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTruckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenSuppliersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem stockTransactionReportToolStripMenuItem1;
        private System.Windows.Forms.GroupBox gbFindItem;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cbFindItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
    }
}