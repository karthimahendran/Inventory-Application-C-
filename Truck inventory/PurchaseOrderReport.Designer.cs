namespace Truck_inventory
{
    partial class PurchaseOrderReport
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
            this.Purchase_Order_Details_ProcedureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.POdataSet = new Truck_inventory.POdataSet();
            this.Purchase_Order_Details_ProcedureTableAdapter = new Truck_inventory.POdataSetTableAdapters.Purchase_Order_Details_ProcedureTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Purchase_Order_Details_ProcedureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.POdataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "POdataSet_Purchase_Order_Details_Procedure";
            reportDataSource1.Value = this.Purchase_Order_Details_ProcedureBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_inventory.POReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(7, 11);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(779, 524);
            this.reportViewer1.TabIndex = 0;
            // 
            // Purchase_Order_Details_ProcedureBindingSource
            // 
            this.Purchase_Order_Details_ProcedureBindingSource.DataMember = "Purchase_Order_Details_Procedure";
            this.Purchase_Order_Details_ProcedureBindingSource.DataSource = this.POdataSet;
            // 
            // POdataSet
            // 
            this.POdataSet.DataSetName = "POdataSet";
            this.POdataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Purchase_Order_Details_ProcedureTableAdapter
            // 
            this.Purchase_Order_Details_ProcedureTableAdapter.ClearBeforeFill = true;
            // 
            // PurchaseOrderReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 539);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PurchaseOrderReport";
            this.Text = "PurchaseOrderReport";
            this.Load += new System.EventHandler(this.PurchaseOrderReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Purchase_Order_Details_ProcedureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.POdataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Purchase_Order_Details_ProcedureBindingSource;
        private POdataSet POdataSet;
        private POdataSetTableAdapters.Purchase_Order_Details_ProcedureTableAdapter Purchase_Order_Details_ProcedureTableAdapter;
    }
}