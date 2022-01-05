using BussinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STOCK
{
    public partial class frmGroupProduct : DevExpress.XtraEditors.XtraForm
    {
        public frmGroupProduct()
        {
            InitializeComponent();
        }
        GroupProductS _dept;
        bool _add;
        int _id;
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
            txtNote.Enabled = tmp;

            checkDisabled.Enabled = tmp;

        }
        void _reset()
        {

            txtName.Text = "";
            txtNote.Text = "";
            checkDisabled.Checked = false;

        }


        void loadData()
        {
            gcIndex.DataSource = _dept.getAll();
            gvIndex.OptionsBehavior.Editable = false;
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
            _add = false;
            showHideControl(false);
            _enabled(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure delete?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _dept.delete(_id);
            }
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_add)
            {
                GroupProduct dept = new GroupProduct();

                dept.NameGProduct = txtName.Text;
                dept.Note = txtNote.Text;

                dept.DISABLED = checkDisabled.Checked;

                _dept.add(dept);

            }
            else
            {
                GroupProduct dept = _dept.getItem(_id);
                dept.NameGProduct = txtName.Text;
                dept.Note = txtNote.Text;

                dept.DISABLED = checkDisabled.Checked;

                _dept.update(dept);

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

        private void frmGroupProduct_Load(object sender, EventArgs e)
        {
            _dept = new GroupProductS();
            showHideControl(true);
            _enabled(false);
            txtName.Enabled = false;
            txtNote.Enabled = false;
            
            loadData();
        }

        private void gvIndex_Click(object sender, EventArgs e)
        {
            if (gvIndex.RowCount > 0)
            {

                _id = (int)gvIndex.GetFocusedRowCellValue("IdGroupProduct");
                txtName.Text = gvIndex.GetFocusedRowCellValue("NameGProduct").ToString();
                txtNote.Text = gvIndex.GetFocusedRowCellValue("Note").ToString();
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

       
    }
}