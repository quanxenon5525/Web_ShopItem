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
    public partial class frmCustomer : DevExpress.XtraEditors.XtraForm
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        CustomerS _cus;
        bool _add;
        string _id;
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            _cus = new CustomerS();
            showHideControl(true);
            _enabled(false);

            loadData();
        }
        void loadData()
        {
            gcIndex.DataSource = _cus.getAll();
            gvIndex.OptionsBehavior.Editable = false;
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

            txtEmail.Enabled = tmp;
            txtAddress.Enabled = tmp;
    
            txtMST.Enabled = tmp;

        }
        void _reset()
        {
            txtMST.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
      
            txtEmail.Text = "";
            txtAddress.Text = "";


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _add = true;
            showHideControl(false);
            _enabled(true);
            _reset();
            txtMST.Enabled = true;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _add = false;
            showHideControl(false);
            _enabled(true);
            txtMST.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure delete?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _cus.delete(_id);
            }
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
            if (_add)
            {
                Customer com = new Customer();
                com.idCustom = txtAddress.Text.Substring(1, 5) + "@" + DateTime.Now.Second.ToString() + txtMST.Text;
                com.FullName = txtName.Text;
                com.Address = txtAddress.Text;
                com.MST = txtMST.Text;
                com.Phone = txtPhone.Text;
                com.Email = txtEmail.Text;
            
                _cus.add(com);

            }
            else
            {
                Customer com = new Customer();
                com.FullName = txtName.Text;
                com.Address = txtAddress.Text;
                com.Phone = txtPhone.Text;
                com.Email = txtEmail.Text;
                com.MST = txtMST.Text;

                _cus.update(com);

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
            txtMST.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvIndex_Click(object sender, EventArgs e)
        {
            if (gvIndex.RowCount > 0)
            {

                _id = gvIndex.GetFocusedRowCellValue("idCustom").ToString();
                txtMST.Text = gvIndex.GetFocusedRowCellValue("MST").ToString();
                txtName.Text = gvIndex.GetFocusedRowCellValue("FullName").ToString();
                txtPhone.Text = gvIndex.GetFocusedRowCellValue("Phone").ToString();
         
                txtEmail.Text = gvIndex.GetFocusedRowCellValue("Email").ToString();
                txtAddress.Text = gvIndex.GetFocusedRowCellValue("Address").ToString();
                

            }
        }

      
    }
}