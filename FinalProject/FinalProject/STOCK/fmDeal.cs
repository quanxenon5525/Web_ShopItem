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
    public partial class fmDeal : DevExpress.XtraEditors.XtraForm
    {
        public fmDeal()
        {
            InitializeComponent();
        }
        List<Order> order;
        DealS list;
        BindingSource source;
        BindingSource source1;
        DealDetailS orderdetail;
        private void fmDeal_Load(object sender, EventArgs e)
        {
            list = new DealS();
            orderdetail = new DealDetailS();
            source = new BindingSource();
            source1 = new BindingSource();

            tabFinance.SelectedTabPage = pageFinancyPaper;

            order = list.getAll();
            source.DataSource = order;
            gcIndex.DataSource = source;
            gvIndex.OptionsBehavior.Editable = false;
            exportInformation();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSkip_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        void exportInformation()
        {
            Order current = (Order)source.Current;
            if(current !=  null)
            {
                source1.DataSource = orderdetail.GetListByDetail(current.idOrder);

                gcDetail.DataSource = source1;
               for(int i =  0; i < gvDetail.RowCount; i++)
                {
                    gvDetail.SetRowCellValue(i, "No", i + 1);
                }
            }
        }

        private void gvIndex_DoubleClick(object sender, EventArgs e)
        {
            if (gvIndex.RowCount > 0)
            {
                tabFinance.SelectedTabPage = pageFinanceDetail;
            }
            exportInformation();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmExportProduct frm = new frmExportProduct();
            frm.ShowDialog();
        }
    }
}