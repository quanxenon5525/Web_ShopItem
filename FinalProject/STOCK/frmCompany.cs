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
    public partial class frmCompany : DevExpress.XtraEditors.XtraForm
    {
        public frmCompany()
        {
            InitializeComponent();
        }
        CompanyS _compt;
        bool _add;
        string _id;

        private void frmCompany_Load(object sender, EventArgs e)
        {
            _compt = new CompanyS();
            showHideControl(true);
            _enabled(false);
            txtCode.Enabled = false;
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
            gcIndex.DataSource = _compt.getAll();
            gvIndex.OptionsBehavior.Editable = false;
        }




        private void btnSkip_Click(object sender, EventArgs e)
        {
            _add = false;
            showHideControl(true);
            _enabled(false);
            txtCode.Enabled = false;
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_add)
            {
                Company com = new Company();
                com.IdCompany = txtCode.Text;
                com.NameCompany = txtName.Text;
                com.Address = txtAddress.Text;
                com.Phone = txtPhone.Text;
                com.Fax = txtFax.Text;
                com.Email = txtEmail.Text;
                com.DISABLED = checkDisabled.Checked;
                _compt.add(com);

            }
            else
            {
                Company com = _compt.getItem(_id);
                com.IdCompany = txtCode.Text;
                com.NameCompany = txtName.Text;
                com.Address = txtAddress.Text;
                com.Phone = txtPhone.Text;
                com.Fax = txtFax.Text;
                com.Email = txtEmail.Text;
                com.DISABLED = checkDisabled.Checked;
                _compt.update(com);

            }
            _add = false;
            loadData();
            _enabled(false);
            showHideControl(true);
            txtCode.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure delete?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _compt.delete(_id);
            }
            loadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _add = false;
            showHideControl(false);
            _enabled(true);
            txtCode.Enabled = false;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
      

        private void gvIndex_Click_1(object sender, EventArgs e)
        {
            if (gvIndex.RowCount > 0)
            {

                _id = gvIndex.GetFocusedRowCellValue("IdCompany").ToString();
                txtCode.Text = gvIndex.GetFocusedRowCellValue("IdCompany").ToString();
                txtName.Text = gvIndex.GetFocusedRowCellValue("NameCompany").ToString();
                txtPhone.Text = gvIndex.GetFocusedRowCellValue("Phone").ToString();
                txtFax.Text = gvIndex.GetFocusedRowCellValue("Fax").ToString();
                txtEmail.Text = gvIndex.GetFocusedRowCellValue("Email").ToString();
                txtAddress.Text = gvIndex.GetFocusedRowCellValue("Address").ToString();
                checkDisabled.Checked = bool.Parse(gvIndex.GetFocusedRowCellValue("DISABLED").ToString());

            }
        }

        private void gvIndex_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
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