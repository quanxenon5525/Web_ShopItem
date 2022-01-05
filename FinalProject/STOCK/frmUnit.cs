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
    public partial class frmUnit : DevExpress.XtraEditors.XtraForm
    {
        public frmUnit()
        {
            InitializeComponent();
        }
        Units _supp;
        bool _add;
        int _id;
        private void frmUnit_Load(object sender, EventArgs e)
        {

            _supp = new Units();
            showHideControl(true);
            _enabled(false);
            txtName.Enabled = false;
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
          

        }
        void _reset()
        {

            txtName.Text = "";
            

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
                _supp.delete(_id);
            }
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_add)
            {
                Unit com = new Unit();

                com.NameUnit = txtName.Text;


                _supp.add(com);

            }
            else
            {
                Unit com = _supp.getItem(_id);
                com.NameUnit = txtName.Text;

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

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvIndex_Click(object sender, EventArgs e)
        {
            if (gvIndex.RowCount > 0)
            {
                _id = (int)gvIndex.GetFocusedRowCellValue("IdUnit");

                txtName.Text = gvIndex.GetFocusedRowCellValue("NameUnit").ToString();
              

            }
        }

      
    }
}