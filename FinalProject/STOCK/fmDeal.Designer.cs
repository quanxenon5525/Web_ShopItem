
namespace STOCK
{
    partial class fmDeal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmDeal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSkip = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BARCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NameProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantily = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnSave,
            this.btnSkip,
            this.btnExport,
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(783, 38);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 35);
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(31, 35);
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 35);
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 35);
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Image = ((System.Drawing.Image)(resources.GetObject("btnSkip.Image")));
            this.btnSkip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(33, 35);
            this.btnSkip.Text = "Skip";
            this.btnSkip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::STOCK.Properties.Resources.icons8_print_48;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(36, 35);
            this.btnExport.Text = "Print";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 35);
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gcDetail
            // 
            this.gcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetail.Location = new System.Drawing.Point(0, 38);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.Size = new System.Drawing.Size(783, 398);
            this.gcDetail.TabIndex = 13;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BARCODE,
            this.NameProduct,
            this.Unit,
            this.Quantily,
            this.Price,
            this.Amount,
            this.No});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Quantily", this.Quantily, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            this.gvDetail.RowHeight = 25;
            // 
            // BARCODE
            // 
            this.BARCODE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BARCODE.AppearanceHeader.Options.UseFont = true;
            this.BARCODE.Caption = "BARCODE";
            this.BARCODE.FieldName = "BARCODE";
            this.BARCODE.MaxWidth = 120;
            this.BARCODE.MinWidth = 120;
            this.BARCODE.Name = "BARCODE";
            this.BARCODE.Visible = true;
            this.BARCODE.VisibleIndex = 0;
            this.BARCODE.Width = 120;
            // 
            // NameProduct
            // 
            this.NameProduct.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NameProduct.AppearanceHeader.Options.UseFont = true;
            this.NameProduct.Caption = "NameProduct";
            this.NameProduct.FieldName = "NameProduct";
            this.NameProduct.MaxWidth = 250;
            this.NameProduct.MinWidth = 250;
            this.NameProduct.Name = "NameProduct";
            this.NameProduct.Visible = true;
            this.NameProduct.VisibleIndex = 1;
            this.NameProduct.Width = 250;
            // 
            // Unit
            // 
            this.Unit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Unit.AppearanceHeader.Options.UseFont = true;
            this.Unit.Caption = "Unit";
            this.Unit.FieldName = "Unit";
            this.Unit.MaxWidth = 80;
            this.Unit.MinWidth = 80;
            this.Unit.Name = "Unit";
            this.Unit.Visible = true;
            this.Unit.VisibleIndex = 2;
            this.Unit.Width = 80;
            // 
            // Quantily
            // 
            this.Quantily.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Quantily.AppearanceHeader.Options.UseFont = true;
            this.Quantily.Caption = "Quantily";
            this.Quantily.FieldName = "Quantily";
            this.Quantily.MaxWidth = 100;
            this.Quantily.MinWidth = 100;
            this.Quantily.Name = "Quantily";
            this.Quantily.Visible = true;
            this.Quantily.VisibleIndex = 3;
            this.Quantily.Width = 100;
            // 
            // Price
            // 
            this.Price.Caption = "Price";
            this.Price.DisplayFormat.FormatString = "{0:N0}";
            this.Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Price.FieldName = "Price";
            this.Price.MaxWidth = 120;
            this.Price.MinWidth = 120;
            this.Price.Name = "Price";
            this.Price.Visible = true;
            this.Price.VisibleIndex = 4;
            this.Price.Width = 120;
            // 
            // Amount
            // 
            this.Amount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Amount.AppearanceHeader.Options.UseFont = true;
            this.Amount.Caption = "Amount";
            this.Amount.DisplayFormat.FormatString = "{0:N0}";
            this.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.FieldName = "Amount";
            this.Amount.MaxWidth = 120;
            this.Amount.MinWidth = 120;
            this.Amount.Name = "Amount";
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 5;
            this.Amount.Width = 120;
            // 
            // No
            // 
            this.No.Caption = "No";
            this.No.FieldName = "No";
            this.No.Name = "No";
            // 
            // fmDeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 436);
            this.Controls.Add(this.gcDetail);
            this.Controls.Add(this.toolStrip1);
            this.Name = "fmDeal";
            this.Text = "Deal";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSkip;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnExit;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn BARCODE;
        private DevExpress.XtraGrid.Columns.GridColumn NameProduct;
        private DevExpress.XtraGrid.Columns.GridColumn Unit;
        private DevExpress.XtraGrid.Columns.GridColumn Quantily;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraGrid.Columns.GridColumn No;
    }
}