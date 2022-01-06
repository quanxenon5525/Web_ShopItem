
namespace STOCK
{
    partial class frmProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSkip = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gcIndex = new DevExpress.XtraGrid.GridControl();
            this.gvIndex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BARCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NameProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NameAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdGroupProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Describe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Disabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.checkDisabled = new System.Windows.Forms.CheckBox();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescribe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.spPrice = new DevExpress.XtraEditors.SpinEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameSort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPrice.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1497, 38);
            this.toolStrip1.TabIndex = 10;
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 38);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Controls.Add(this.gcIndex);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1497, 545);
            this.splitContainerControl1.SplitterPosition = 454;
            this.splitContainerControl1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbGroup);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 60);
            this.panel1.TabIndex = 1;
            // 
            // cbGroup
            // 
            this.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(177, 18);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(348, 21);
            this.cbGroup.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(103, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "Group";
            // 
            // gcIndex
            // 
            this.gcIndex.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gcIndex.Location = new System.Drawing.Point(0, 86);
            this.gcIndex.MainView = this.gvIndex;
            this.gcIndex.Name = "gcIndex";
            this.gcIndex.Size = new System.Drawing.Size(1033, 459);
            this.gcIndex.TabIndex = 0;
            this.gcIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvIndex});
            // 
            // gvIndex
            // 
            this.gvIndex.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvIndex.Appearance.Row.Options.UseFont = true;
            this.gvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BARCODE,
            this.NameProduct,
            this.NameAT,
            this.Unit,
            this.Price,
            this.IdSupplier,
            this.IdSource,
            this.IdGroupProduct,
            this.Describe,
            this.Disabled});
            this.gvIndex.GridControl = this.gcIndex;
            this.gvIndex.Name = "gvIndex";
            this.gvIndex.OptionsView.ShowGroupPanel = false;
            this.gvIndex.RowHeight = 25;
            this.gvIndex.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvIndex_CustomDrawCell);
            this.gvIndex.Click += new System.EventHandler(this.gvIndex_Click);
            // 
            // BARCODE
            // 
            this.BARCODE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BARCODE.AppearanceHeader.Options.UseFont = true;
            this.BARCODE.Caption = "BARCODE";
            this.BARCODE.FieldName = "BARCODE";
            this.BARCODE.MaxWidth = 100;
            this.BARCODE.MinWidth = 100;
            this.BARCODE.Name = "BARCODE";
            this.BARCODE.Visible = true;
            this.BARCODE.VisibleIndex = 0;
            this.BARCODE.Width = 100;
            // 
            // NameProduct
            // 
            this.NameProduct.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NameProduct.AppearanceHeader.Options.UseFont = true;
            this.NameProduct.Caption = "NameProduct";
            this.NameProduct.FieldName = "NameProduct";
            this.NameProduct.MaxWidth = 400;
            this.NameProduct.MinWidth = 400;
            this.NameProduct.Name = "NameProduct";
            this.NameProduct.Visible = true;
            this.NameProduct.VisibleIndex = 1;
            this.NameProduct.Width = 400;
            // 
            // NameAT
            // 
            this.NameAT.Caption = "NameAT";
            this.NameAT.FieldName = "NameAT";
            this.NameAT.Name = "NameAT";
            // 
            // Unit
            // 
            this.Unit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Unit.AppearanceHeader.Options.UseFont = true;
            this.Unit.Caption = "Unit";
            this.Unit.FieldName = "Unit";
            this.Unit.MaxWidth = 50;
            this.Unit.MinWidth = 50;
            this.Unit.Name = "Unit";
            this.Unit.Visible = true;
            this.Unit.VisibleIndex = 2;
            this.Unit.Width = 50;
            // 
            // Price
            // 
            this.Price.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Price.AppearanceHeader.Options.UseFont = true;
            this.Price.Caption = "Price";
            this.Price.DisplayFormat.FormatString = "{0:N0}";
            this.Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Price.FieldName = "Price";
            this.Price.MaxWidth = 100;
            this.Price.MinWidth = 100;
            this.Price.Name = "Price";
            this.Price.Visible = true;
            this.Price.VisibleIndex = 3;
            this.Price.Width = 100;
            // 
            // IdSupplier
            // 
            this.IdSupplier.Caption = "IdSupplier";
            this.IdSupplier.FieldName = "IdSupplier";
            this.IdSupplier.Name = "IdSupplier";
            // 
            // IdSource
            // 
            this.IdSource.Caption = "IdSource";
            this.IdSource.FieldName = "IdSource";
            this.IdSource.Name = "IdSource";
            // 
            // IdGroupProduct
            // 
            this.IdGroupProduct.Caption = "IdGroupProduct";
            this.IdGroupProduct.FieldName = "IdGroupProduct";
            this.IdGroupProduct.Name = "IdGroupProduct";
            // 
            // Describe
            // 
            this.Describe.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Describe.AppearanceHeader.Options.UseFont = true;
            this.Describe.Caption = "Describe";
            this.Describe.FieldName = "Note";
            this.Describe.MaxWidth = 300;
            this.Describe.MinWidth = 300;
            this.Describe.Name = "Describe";
            this.Describe.Visible = true;
            this.Describe.VisibleIndex = 4;
            this.Describe.Width = 300;
            // 
            // Disabled
            // 
            this.Disabled.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Disabled.AppearanceHeader.Options.UseFont = true;
            this.Disabled.Caption = "Disabled";
            this.Disabled.FieldName = "DISABLED";
            this.Disabled.MaxWidth = 50;
            this.Disabled.MinWidth = 50;
            this.Disabled.Name = "Disabled";
            this.Disabled.Visible = true;
            this.Disabled.VisibleIndex = 5;
            this.Disabled.Width = 50;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.cbSource);
            this.groupControl1.Controls.Add(this.checkDisabled);
            this.groupControl1.Controls.Add(this.cbSupplier);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.txtDescribe);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.cbUnit);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.spPrice);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.txtNameSort);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtName);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtBarcode);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(454, 545);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Information Product";
            // 
            // cbSource
            // 
            this.cbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Location = new System.Drawing.Point(62, 400);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(150, 21);
            this.cbSource.TabIndex = 18;
            // 
            // checkDisabled
            // 
            this.checkDisabled.AutoSize = true;
            this.checkDisabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkDisabled.ForeColor = System.Drawing.Color.Blue;
            this.checkDisabled.Location = new System.Drawing.Point(62, 457);
            this.checkDisabled.Name = "checkDisabled";
            this.checkDisabled.Size = new System.Drawing.Size(81, 17);
            this.checkDisabled.TabIndex = 17;
            this.checkDisabled.Text = "DISABLED";
            this.checkDisabled.UseVisualStyleBackColor = true;
            // 
            // cbSupplier
            // 
            this.cbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(62, 430);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(279, 21);
            this.cbSupplier.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Supplier";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 403);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Source";
            // 
            // txtDescribe
            // 
            this.txtDescribe.Location = new System.Drawing.Point(62, 238);
            this.txtDescribe.Multiline = true;
            this.txtDescribe.Name = "txtDescribe";
            this.txtDescribe.Size = new System.Drawing.Size(164, 147);
            this.txtDescribe.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Describe";
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(72, 195);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(59, 21);
            this.cbUnit.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Unit";
            // 
            // spPrice
            // 
            this.spPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spPrice.Location = new System.Drawing.Point(72, 147);
            this.spPrice.Name = "spPrice";
            this.spPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.spPrice.Properties.Appearance.Options.UseFont = true;
            this.spPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spPrice.Size = new System.Drawing.Size(154, 22);
            this.spPrice.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Price";
            // 
            // txtNameSort
            // 
            this.txtNameSort.Location = new System.Drawing.Point(72, 103);
            this.txtNameSort.Name = "txtNameSort";
            this.txtNameSort.Size = new System.Drawing.Size(346, 21);
            this.txtNameSort.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "NameSort";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(72, 76);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(346, 21);
            this.txtName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(72, 40);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(154, 21);
            this.txtBarcode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Barcode";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportExcelToolStripMenuItem,
            this.exportPDFToolStripMenuItem,
            this.exportWordToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 70);
            // 
            // exportExcelToolStripMenuItem
            // 
            this.exportExcelToolStripMenuItem.Name = "exportExcelToolStripMenuItem";
            this.exportExcelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportExcelToolStripMenuItem.Text = "Export Excel";
            this.exportExcelToolStripMenuItem.Click += new System.EventHandler(this.exportExcelToolStripMenuItem_Click);
            // 
            // exportPDFToolStripMenuItem
            // 
            this.exportPDFToolStripMenuItem.Name = "exportPDFToolStripMenuItem";
            this.exportPDFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportPDFToolStripMenuItem.Text = "Export PDF";
            this.exportPDFToolStripMenuItem.Click += new System.EventHandler(this.exportPDFToolStripMenuItem_Click);
            // 
            // exportWordToolStripMenuItem
            // 
            this.exportWordToolStripMenuItem.Name = "exportWordToolStripMenuItem";
            this.exportWordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportWordToolStripMenuItem.Text = "Export Word";
            this.exportWordToolStripMenuItem.Click += new System.EventHandler(this.exportWordToolStripMenuItem_Click);
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1497, 583);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmProduct";
            this.Text = "frmProduct";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPrice.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton btnExit;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIndex;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn BARCODE;
        private DevExpress.XtraGrid.Columns.GridColumn NameProduct;
        private DevExpress.XtraGrid.Columns.GridColumn NameAT;
        private DevExpress.XtraGrid.Columns.GridColumn Unit;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraGrid.Columns.GridColumn IdSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn IdSource;
        private DevExpress.XtraGrid.Columns.GridColumn IdGroupProduct;
        private DevExpress.XtraGrid.Columns.GridColumn Describe;
        private DevExpress.XtraGrid.Columns.GridColumn Disabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private DevExpress.XtraEditors.SpinEdit spPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNameSort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescribe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.CheckBox checkDisabled;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportWordToolStripMenuItem;
    }
}