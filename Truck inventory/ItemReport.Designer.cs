namespace Truck_inventory
{
    partial class ItemReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StockInHandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StockInHandDataSet = new Truck_inventory.StockInHandDataSet();
            this.StockInHandTableAdapter = new Truck_inventory.StockInHandDataSetTableAdapters.StockInHandTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.StockInHandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockInHandDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "StockInHandDataSet_StockInHand";
            reportDataSource1.Value = this.StockInHandBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_inventory.StockInHandReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(8, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(759, 513);
            this.reportViewer1.TabIndex = 0;
            // 
            // StockInHandBindingSource
            // 
            this.StockInHandBindingSource.DataMember = "StockInHand";
            this.StockInHandBindingSource.DataSource = this.StockInHandDataSet;
            // 
            // StockInHandDataSet
            // 
            this.StockInHandDataSet.DataSetName = "StockInHandDataSet";
            this.StockInHandDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StockInHandTableAdapter
            // 
            this.StockInHandTableAdapter.ClearBeforeFill = true;
            // 
            // ItemReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 526);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ItemReport";
            this.Text = "ItemReport";
            this.Load += new System.EventHandler(this.ItemReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockInHandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockInHandDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource StockInHandBindingSource;
        private StockInHandDataSet StockInHandDataSet;
        private StockInHandDataSetTableAdapters.StockInHandTableAdapter StockInHandTableAdapter;
    }
}