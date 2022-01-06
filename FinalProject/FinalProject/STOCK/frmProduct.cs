using BussinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;




namespace STOCK
{
    public partial class frmProduct : DevExpress.XtraEditors.XtraForm
    {
        public frmProduct()
        {
            InitializeComponent();
        }
        //SYS_USER _user;
        int _right;
        ProductS _compt;
        Units _unit;
        SupplierS _sup;
        SYS_SEQUENCES _seq;
        SYS_SEQUENCE _dbseq;
        GroupProductS _group;
        string _barcode;
        SourceS _source;
        List<objProduct> list_product;


        //Company _compt;
        bool _add;



        private void frmProduct_Load(object sender, EventArgs e)
        {
            _sup = new SupplierS();
            _unit = new Units();
            _group = new GroupProductS();
            _source = new SourceS();
            _compt = new ProductS();
            _seq = new SYS_SEQUENCES();
            _dbseq = new SYS_SEQUENCE();



                 

            
            showHideControl(true);
            _enabled(false);
            loadGroup();
            loadSupplier();
            loadUnit();
            loadSource();
            loadData();
            cbGroup.SelectedIndexChanged += CbGroup_SelectedIndexChanged;
        }

        private void CbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        void showHideControl(bool tmp)
        {
            btnAdd.Visible = tmp;
            btnEdit.Visible = tmp;
            btnDelete.Visible = tmp;
            btnExit.Visible = tmp;
            btnSave.Visible = !tmp;
            btnSkip.Visible = !tmp;
        }
        void _enabled(bool tmp)
        {

            txtName.Enabled = tmp;
            txtNameSort.Enabled = tmp;
            txtDescribe.Enabled = tmp;
            cbUnit.Enabled = tmp;
            spPrice.Enabled = tmp;
            cbSupplier.Enabled = tmp;
            cbSource.Enabled = tmp;
            checkDisabled.Enabled = tmp;
          
        }
        void _reset()
        {
            txtBarcode.Text = "";
            txtName.Text = "";
            txtNameSort.Text= "";
            txtDescribe.Text = "";

        }

        void loadGroup()
        {
            cbGroup.DataSource = _group.getAll();
            cbGroup.DisplayMember = "NameGProduct";
            cbGroup.ValueMember = "IdGroupProduct";
        }

        void loadUnit()
        {
            cbUnit.DataSource = _unit.getAll();
            cbUnit.DisplayMember = "NameUnit";
            cbUnit.ValueMember = "IdUnit";
        }
        void loadSupplier()
        {
            cbSupplier.DataSource = _sup.getAll();
            cbSupplier.DisplayMember = "NameSupplier";
            cbSupplier.ValueMember = "IdSupplier";
        }
        void loadSource()
        {
            cbSource.DataSource = _source.getAll();
            cbSource.DisplayMember = "NameSource";
            cbSource.ValueMember = "IdSource";
        }

        void loadData()
        {
            gcIndex.DataSource = _compt.getListByGroup(int.Parse(cbGroup.SelectedValue.ToString())); 
            gvIndex.OptionsBehavior.Editable = false;
            list_product = _compt.getListByGroupFull(int.Parse(cbGroup.SelectedValue.ToString()));
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _add = true;
            showHideControl(false);
            _enabled(true);
            _reset();
            checkDisabled.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if(_right == 1)
            //{
            //    MessageBox.Show("Not role action", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            _add = false;
            showHideControl(false);
            _enabled(true);
        }
     


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure delete?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _compt.delete(_barcode);
            }
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_add)
            {
                Product dept = new Product();
                _dbseq = _seq.getItem("BEAE@" + DateTime.Now.Year + "@" + cbGroup.SelectedValue.ToString());
                if(_dbseq == null)
                {
                    _dbseq = new SYS_SEQUENCE();
                    _dbseq.SEQNAME = "BEAE@" + DateTime.Now.Year + "@" + cbGroup.SelectedValue.ToString();
                    _dbseq.SEQVALUE = 1;
                    _seq.add(_dbseq);
                }

                dept.BARCODE = EAN13.BuildEAN13(DateTime.Now.Year.ToString() + cbGroup.SelectedValue.ToString() + _dbseq.SEQVALUE.Value.ToString("0000000"));
                dept.NameProduct = txtName.Text;
                dept.NameAT = txtNameSort.Text;
                dept.IdGroupProduct = int.Parse(cbGroup.SelectedValue.ToString());
                dept.Note = txtDescribe.Text;
                dept.IdSupplier = cbSupplier.SelectedValue.ToString();
                dept.IdSource = int.Parse(cbSource.SelectedValue.ToString());
                dept.Unit = cbUnit.Text;
                dept.DISABLED = checkDisabled.Checked;
                dept.CREATE_DATE = DateTime.Now;
                dept.CREATE_BY = 1;
                dept.Price = float.Parse(spPrice.Text);
                var pro =   _compt.add(dept);
                txtBarcode.Text = pro.BARCODE;
                _seq.update(_dbseq);
                //MessageBox.Show(dept.BARCODE);

            }
            else
            {
                Product dept = _compt.getItem(_barcode);
                dept.NameProduct = txtName.Text;
                dept.NameAT = txtNameSort.Text;
                dept.IdGroupProduct = int.Parse(cbGroup.SelectedValue.ToString());
                dept.Note = txtDescribe.Text;
                dept.IdSupplier = cbSupplier.SelectedValue.ToString();
                dept.IdSource = int.Parse(cbSource.SelectedValue.ToString());
                dept.Unit = cbUnit.Text;
                dept.DISABLED = checkDisabled.Checked;
            
                dept.Price = float.Parse(spPrice.Text);
                var pro = _compt.update(dept);
                txtBarcode.Text = pro.BARCODE;
             


            }
            _add = false;
            loadData();
            _enabled(false);
            showHideControl(true);
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            _add = false;
            showHideControl(true);
            _enabled(false);
            loadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void gvIndex_Click(object sender, EventArgs e)
        {
            if (gvIndex.RowCount > 0)
            {
                _barcode = gvIndex.GetFocusedRowCellValue("BARCODE").ToString();
                txtBarcode.Text = gvIndex.GetFocusedRowCellValue("BARCODE").ToString();
                txtName.Text = gvIndex.GetFocusedRowCellValue("NameProduct").ToString();
                cbSource.SelectedValue =  gvIndex.GetFocusedRowCellValue("IdSource");
                txtNameSort.Text = gvIndex.GetFocusedRowCellValue("NameAT").ToString();
                cbSupplier.SelectedValue = gvIndex.GetFocusedRowCellValue("IdSupplier").ToString();
                txtDescribe.Text =  gvIndex.GetFocusedRowCellValue("Note").ToString();
                cbUnit.Text = gvIndex.GetFocusedRowCellValue("Unit").ToString();
                spPrice.Text = gvIndex.GetFocusedRowCellValue("Price").ToString();
                checkDisabled.Checked = bool.Parse(gvIndex.GetFocusedRowCellValue("DISABLED").ToString());

            }
        }

        private void gvIndex_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "DISABLED" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.delete_icon;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);

                e.Handled = true;
            }
        }

     

        private void exportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel 2007 or higher(.xlsx)|*.xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                gvIndex.ExportToXlsx(saveFile.FileName);
            }
        }

        private void exportPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF file(.pdf)|*.pdf";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                gvIndex.ExportToPdf(saveFile.FileName);
            }
        }

        private void exportWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Word 2007 or higher(.docx)|*.docx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                gvIndex.ExportToDocx(saveFile.FileName);
            }
        }

     
    }
}