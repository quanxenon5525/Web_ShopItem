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
    public partial class frmDepartment : DevExpress.XtraEditors.XtraForm
    {
        public frmDepartment()
        {
            InitializeComponent();
        }
        DepartmentS _dept;
        CompanyS _compt;
        bool _add;
        string _id;


        private void frmDepartment_Load(object sender, EventArgs e)
        {
            _dept = new DepartmentS();
            _compt = new CompanyS();
            loadCompany();
            showHideControl(true);
            _enabled(false);
            txtCode.Enabled = false;
            cbCompany.SelectedIndexChanged += cbCompany_SelectedIndexChanged;
            loadDepartmentByCompany();



        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDepartmentByCompany();
                
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
            checkStock.Enabled = tmp;
            txtSyntax.Enabled = tmp;
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
            checkStock.Checked = false;
            txtSyntax.Text = "";
        }

        void loadCompany()
        {
            cbCompany.DataSource = _compt.getAll();
            cbCompany.DisplayMember = "NameCompany";
            cbCompany.ValueMember = "IdCompany";
        }
        void loadDepartmentByCompany()
        {
            gcIndex.DataSource = _dept.getAll(cbCompany.SelectedValue.ToString());
            gvIndex.OptionsBehavior.Editable = false;
        }
       

     

        private void btnSkip_Click(object sender, EventArgs e)
        {
            _add = false;
            showHideControl(true);
            _enabled(false);
            txtCode.Enabled = false;
            loadDepartmentByCompany();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_add)
            {
                Department dept = new Department();
                dept.IdDepartment = txtCode.Text;
                dept.IdCompany = cbCompany.SelectedValue.ToString();
                dept.NameDepartment = txtName.Text;
                dept.Address = txtAddress.Text;
                dept.Phone = txtPhone.Text;
                dept.Fax = txtFax.Text;
                dept.Email = txtEmail.Text;
                dept.DISABLED = checkDisabled.Checked;
                dept.STOCK = checkStock.Checked;
                dept.Syntax = txtSyntax.Text;
                _dept.add(dept);

            }
            else
            {
                Department dept = _dept.getItem(_id);
                dept.IdDepartment = txtCode.Text;
                dept.IdCompany = cbCompany.SelectedValue.ToString();
                dept.NameDepartment = txtName.Text;
                dept.Address = txtAddress.Text;
                dept.Phone = txtPhone.Text;
                dept.Fax = txtFax.Text;
                dept.Email = txtEmail.Text;
                dept.DISABLED = checkDisabled.Checked;
                dept.STOCK = checkStock.Checked;
                dept.Syntax = txtSyntax.Text;
                _dept.update(dept);

            }
            _add = false;
            loadDepartmentByCompany();
            _enabled(false);
            showHideControl(true);
            txtCode.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you sure delete?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _dept.delete(_id);
            }
            loadDepartmentByCompany();
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

        private void gvIndex_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.FieldName == "DISABLED" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.delete_icon;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);

                e.Handled = true;
            }
        }

        private void gvIndex_Click(object sender, EventArgs e)
        {
            if(gvIndex.RowCount > 0)
            {
                
                _id = gvIndex.GetFocusedRowCellValue("IdDepartment").ToString();
                cbCompany.SelectedValue = gvIndex.GetFocusedRowCellValue("IdCompany");
                txtCode.Text = gvIndex.GetFocusedRowCellValue("IdDepartment").ToString();
                txtName.Text = gvIndex.GetFocusedRowCellValue("NameDepartment").ToString();
                txtPhone.Text = gvIndex.GetFocusedRowCellValue("Phone").ToString();
                txtFax.Text = gvIndex.GetFocusedRowCellValue("Fax").ToString();
                txtEmail.Text = gvIndex.GetFocusedRowCellValue("Email").ToString();
                txtAddress.Text = gvIndex.GetFocusedRowCellValue("Address").ToString();
                checkDisabled.Checked = bool.Parse(gvIndex.GetFocusedRowCellValue("DISABLED").ToString());
                checkStock.Checked = bool.Parse(gvIndex.GetFocusedRowCellValue("STOCK").ToString());
                txtSyntax.Text = gvIndex.GetFocusedRowCellValue("Syntax").ToString();
              
            }
        }
    }
}