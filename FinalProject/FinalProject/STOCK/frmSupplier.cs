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
    public partial class frmSupplier : DevExpress.XtraEditors.XtraForm
    {
        public frmSupplier()
        {
            InitializeComponent();
        }
        SupplierS _supp;
        bool _add;
        string _id;

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            _supp = new SupplierS();
            showHideControl(true);
            _enabled(false);
          
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
            txtPhone.Enabled = tmp;
            txtFax.Enabled = tmp;
            txtEmail.Enabled = tmp;
            txtAddress.Enabled = tmp;
            checkDisabled.Enabled = tmp;
            txtCode.Enabled = tmp;

        }
        void _reset()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            checkDisabled.Checked = false;

        }


        void loadData()
        {
            gcIndex.DataSource = _supp.getAll();
            gvIndex.OptionsBehavior.Editable = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _add = true;
            showHideControl(false);
            _enabled(true);
            _reset();
            txtCode.Enabled = true;
            checkDisabled.Enabled = false;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _add = false;
            showHideControl(false);
            _enabled(true);
            txtCode.Enabled = false;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure delete?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _supp.delete(_id);
            }
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCode.Text == "")
            {
                MessageBox.Show("Please Input Id Supplier", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_add)
            {
                Supplier com = new Supplier();
                com.IdSupplier = txtCode.Text;
                com.NameSupplier = txtName.Text;
                com.Address = txtAddress.Text;
                com.Phone = txtPhone.Text;
                com.Fax = txtFax.Text;
                com.Email = txtEmail.Text;
                com.DISABLED = checkDisabled.Checked;
                com.CREATED_DATE = DateTime.Now;
                _supp.add(com);

            }
            else
            {
                Supplier com = _supp.getItem(_id);
                com.IdSupplier = txtCode.Text;
                com.NameSupplier = txtName.Text;
                com.Address = txtAddress.Text;
                com.Phone = txtPhone.Text;
                com.Fax = txtFax.Text;
                com.Email = txtEmail.Text;
                com.DISABLED = checkDisabled.Checked;
                _supp.update(com);

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
            txtCode.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvIndex_Click(object sender, EventArgs e)
        {
            if (gvIndex.RowCount > 0)
            {

                _id = gvIndex.GetFocusedRowCellValue("IdSupplier").ToString();
                 txtCode.Text = gvIndex.GetFocusedRowCellValue("IdSupplier").ToString();
                txtName.Text = gvIndex.GetFocusedRowCellValue("NameSupplier").ToString();
                txtPhone.Text = gvIndex.GetFocusedRowCellValue("Phone").ToString();
                txtFax.Text = gvIndex.GetFocusedRowCellValue("Fax").ToString();
                txtEmail.Text = gvIndex.GetFocusedRowCellValue("Email").ToString();
                txtAddress.Text = gvIndex.GetFocusedRowCellValue("Address").ToString();
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