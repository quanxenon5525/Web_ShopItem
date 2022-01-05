using BussinessLayer;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using STOCK.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace STOCK
{
    public partial class frmPurchaseEntry : DevExpress.XtraEditors.XtraForm
    {
        public frmPurchaseEntry()
        {
            InitializeComponent();
        }
        bool _add;
        bool _edit = false;
        bool _isImport;
        Guid _keydetail;
        string error = "";
        List<_Status> _status;
        CompanyS _comp;
        DepartmentS _dept;
        SupplierS _sup;
        SYS_SEQUENCES _seq;
        ProductS _pro;
        FinancyPaperS fp;
        FinancyDetailS fpd;
        Guid _key;
        Guid _keyFin;
        SYS_SEQUENCE _dbseq;
        //List<objProduct> list_product = new List<objProduct>();
        //Excel.Application appExcel;
        BindingSource _bdfinanceDetail;
        BindingSource _bdfinance;
        List<string> _lstBarcode;
        List<FinancialPaper> _lstF;


        private void frmPurchaseEntry_Load(object sender, EventArgs e)
        {
            _isImport = false;
            _lstBarcode = new List<string>();
            _comp = new CompanyS();
            _dept = new DepartmentS();
            fp = new FinancyPaperS();
            fpd = new FinancyDetailS();
            _pro = new ProductS();
            _sup = new SupplierS();
            _seq = new SYS_SEQUENCES();
            _dbseq = new SYS_SEQUENCE();
            _bdfinance = new BindingSource();
            _bdfinanceDetail = new BindingSource();


            //list_product = new List<objProduct>();




            tabFinance.SelectedTabPage = pageFinancyPaper;

            dtSince.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtToDate.Value = DateTime.Now;


            _bdfinance.PositionChanged += _bdfinance_PositionChanged;
            loadCompany();
            cbCompany.SelectedValue = "COPC";
            cbCompany.SelectedIndexChanged += cbCompany_SelectedIndexChanged;

            _status = _Status.getList();
            cbStatus.DataSource = _status;
            cbStatus.DisplayMember = "_display";
            cbStatus.ValueMember = "_value";

            loadSupplier();
            loadDepartment();


            _lstF = fp.getList(1, dtSince.Value, dtToDate.Value.AddDays(1), cbStock.SelectedValue.ToString());

            _bdfinance.DataSource = _lstF;
            gcIndex.DataSource = _bdfinance;
            gvIndex.OptionsBehavior.Editable = false;

         
            exportInformation();
            //cbDepartment.SelectedIndexChanged += cbCompany_SelectedIndexChanged;

        
                cbStock.SelectedIndexChanged += cbStock_SelectedIndexChanged;

            

            showHideControls(true);

          
         


        }

        //private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void cbStock_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            _lstF = fp.getList(1, dtSince.Value, dtToDate.Value.AddDays(1), cbStock.SelectedValue.ToString());
            _bdfinance.DataSource = _lstF;
            gcIndex.DataSource = _bdfinance;

            exportInformation();
            loadStock();
           
           
         
               cbDepartment.SelectedIndex = cbStock.SelectedIndex;
            
          
        }

      
        void exportInformation()
        {   
            FinancialPaper current = (FinancialPaper)_bdfinance.Current;
            if (current != null && current.Category == 1)
            {
               
                _keyFin = current.KeyFinance;
                dtDate.Value = current.Date.Value;
                txtNo.Text = current.NoFP;
                txtNote.Text = current.Note;
                cbDepartment.SelectedValue = current.IdDepartment;
                cbSupplier.SelectedValue = current.IdDepartment2;

                cbStatus.SelectedValue = current.Status;
                
                btnDelete.Enabled = true;

                _bdfinanceDetail.DataSource = fpd.getListByKeyDetail(current.KeyFinance);

                gcDetail.DataSource = _bdfinanceDetail;
                for(int i = 0; i < gvDetail.RowCount; i++)
                {
                    gvDetail.SetRowCellValue(i, "No", i + 1);
                }
                //gvIndex.ClearSelection();
            }

        }


        private void _bdfinance_PositionChanged(object sender, EventArgs e)
        {
            if (!_add)
            {
                exportInformation();
            }
         
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

            //loadStock();

            loadDepartment();
        }

        void showHideControls(bool tmp)
        {
            btnSave.Visible = !tmp;
            btnSkip.Visible = !tmp;
            btnAdd.Visible = tmp;
            btnEdit.Visible = tmp;
            btnDelete.Visible = tmp;

        }
        void _Control(bool tmp)
        {
            
            txtNote.Enabled = tmp;
            cbStatus.Enabled = tmp;
            //cbDepartment.Enabled = tmp;
            cbSupplier.Enabled = tmp;
            dtSince.Enabled = tmp;
            dtDate.Enabled = tmp;
        }
        void _reset()
        {
            txtNo.Text = "";
            txtNote.Text = "";
        }
        void loadCompany()
        {
            cbCompany.DataSource = _comp.getAll();
            cbCompany.DisplayMember = "NameCompany";
            cbCompany.ValueMember = "IdCompany";

        }
      
       
        void loadDepartment()
        {
            cbStock.DataSource = _dept.getStockByCompany(cbCompany.SelectedValue.ToString());
            cbStock.DisplayMember = "NameDepartment";
            cbStock.ValueMember = "IdDepartment";
          


        }
        void loadStock()
        {
            cbDepartment.DataSource = _dept.getStockByCompany(cbCompany.SelectedValue.ToString());
            cbDepartment.DisplayMember = "NameDepartment";
            cbDepartment.ValueMember = "IdDepartment";



        }

        void loadSupplier()
        {
            cbSupplier.DataSource = _sup.getAll();
            cbSupplier.DisplayMember = "NameSupplier";
            cbSupplier.ValueMember = "IdSupplier";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbDepartment.Text))
            {
                MessageBox.Show("Please select STOCK before create form! Thank You", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
              


                _bdfinanceDetail.DataSource = fpd.getListByKeyDetail(_key);
                gcDetail.DataSource = _bdfinanceDetail;

                gvDetail.AddNewRow();

                tabFinance.SelectedTabPage = pageFinanceDetail;
                cbDepartment.Enabled = false;
                gvDetail.OptionsBehavior.Editable = true;
                contextMenuDetail.Enabled = true;
                _add = true;
                _edit = false;
                showHideControls(false);
                _Control(true);
                _reset();
            }
        




        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FinancialPaper current = (FinancialPaper)_bdfinance.Current;
            if(current.Status == 1)
            {
                _add = false;
                _edit = true;
                showHideControls(false);
                _Control(true);
                tabFinance.SelectedTabPage = pageFinanceDetail;
                tabFinance.TabPages[0].PageEnabled = false;
                gvDetail.OptionsBehavior.Editable = true;
                //contextMenuDetail.Enabled = true;
                contextMenuDetail.Enabled = true;
                cbDepartment.Enabled = false;
                if(gvDetail.RowCount == 0)
                {
                    List<FinancialPaperDetail> _lstdetail = new List<FinancialPaperDetail>();
                    _bdfinance.DataSource = _lstdetail;
                    gcDetail.DataSource = _bdfinance;
                    gvDetail.AddNewRow();
                    gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "No", 1);
                }
            }
        }

        private void Finance_Info(FinancialPaper finance)
        {
            double _sum = 0;
            int _quantily = 0;
            Department _dep = _dept.getItem(cbDepartment.SelectedValue.ToString());
            _dbseq = _seq.getItem("NHM@" + DateTime.Today.Year.ToString() + "@" + _dep.Syntax);
            if(_dbseq == null)
            {
                _dbseq = new SYS_SEQUENCE();
                _dbseq.SEQNAME = "NHM@" + DateTime.Today.Year.ToString() +"@"+ _dep.Syntax;
                _dbseq.SEQVALUE = 1;
                _seq.add(_dbseq);
            }
            if (_add)
            {
                finance.KeyFinance = Guid.NewGuid();
                finance.Date = dtDate.Value;
                finance.NoFP = _dbseq.SEQVALUE.Value.ToString("000000") + @"/" + DateTime.Today.Year.ToString().Substring(2, 2) + @"/NHM" + _dep.Syntax;
                finance.CREATED_DATE = DateTime.Now;
            }
            finance.Category = 1;
            finance.IdCompany = cbCompany.SelectedValue.ToString();
            finance.IdDepartment = cbDepartment.SelectedValue.ToString();
            finance.IdDepartment2 = cbSupplier.SelectedValue.ToString();
            finance.Status = int.Parse(cbStatus.SelectedValue.ToString());
            finance.Note = txtNote.Text;

          


            for (int i =  0; i < gvDetail.RowCount; i++)
            {
                if(gvDetail.GetRowCellValue(i, "NameProduct") == null)
                {
                    gvDetail.DeleteRow(i);
                    goto NEXT;
                }
                else
                {
                    _quantily += int.Parse(gvDetail.GetRowCellValue(i, gvDetail.Columns["Quantily"]).ToString());
                    _sum += double.Parse(gvDetail.GetRowCellValue(i, gvDetail.Columns["Amount"]).ToString());

                }
            }
        NEXT:
            finance.Quantily = _quantily;
            finance.Sum = _sum;
            finance.UPDATE_DATE = DateTime.Now;

        }
        void FinanceDetail_info(FinancialPaper finance)
        {
            fpd.deleteAll(finance.KeyFinance);
            for (int i =  0; i < gvDetail.RowCount; i++)
            {
                if(gvDetail.GetRowCellValue(i, "NameProduct") == null)
                
                    gvDetail.DeleteRow(i);
                
                else
                {
                    FinancialPaperDetail _fpdt = new FinancialPaperDetail();
                    _fpdt.KeyDetail = Guid.NewGuid();
                    _fpdt.KeyFinace = finance.KeyFinance;
                    _fpdt.No = i + 1;
                    _fpdt.Date = dtDate.Value;
                    _fpdt.BARCODE = gvDetail.GetRowCellValue(i, "BARCODE").ToString();
                    _fpdt.Quantily = int.Parse(gvDetail.GetRowCellValue(i, "Quantily").ToString());

                    _fpdt.Price = double.Parse(gvDetail.GetRowCellValue(i, "Price").ToString());
                    _fpdt.Amount = double.Parse(gvDetail.GetRowCellValue(i, "Amount").ToString());
                    fpd.add(_fpdt);
                }
            }
        }
        private void saveInformation()
        {
            error = "";
            FinancialPaper _fin;
            if (gvDetail.RowCount == 0)
            {
                error += "Information FinancePaper not is null! Please you check again";
                MessageBox.Show("Information FinancePaper not is null! Please you check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           if(gvDetail.RowCount == 1 && gvDetail.GetRowCellValue(0, "BARCODE") == null)
            {

                error += "Information FinancePaper not is null! Please you check again";
                MessageBox.Show("Information FinancePaper not is null! Please you check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_add)
            {
                _fin = new FinancialPaper();
                Finance_Info(_fin);
                var tmp = fp.add(_fin);
                _seq.update(_dbseq);

                FinanceDetail_info(tmp);
                _bdfinance.Add(tmp);
                _bdfinance.MoveLast();
             


            }
            else
            {
                _fin = (FinancialPaper)_bdfinance.Current;
                _fin = fp.getItem(_fin.KeyFinance);
                Finance_Info(_fin);
                var tmp = fp.update(_fin);
                FinanceDetail_info(tmp);
                
                _lstF = null;
                _lstF = fp.getList(1, dtSince.Value, dtToDate.Value.AddDays(1), cbDepartment.SelectedValue.ToString());

                _bdfinance.DataSource = _lstF;
                gvIndex.ClearSorting();
                gvIndex.RefreshData();
                var obj = _bdfinance.List.OfType<FinancialPaper>().ToList().Find(c => c.NoFP == tmp.NoFP);
                _bdfinance.Position = _bdfinance.IndexOf(obj);

            }
            exportInformation();
            _add = false;
            tabFinance.SelectedTabPage = pageFinancyPaper;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Guid keydetail =Guid.Parse(gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle,"BARCODE").ToString());
            if (tabFinance.SelectedTabPage ==  pageFinancyPaper)
            {
                int index = 0;
                if (gvIndex.GetRowCellValue(gvIndex.FocusedRowHandle, "NoFP") != null)
                {
                    if(gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle,"BARCODE") == null)
                    {
                        if (_add)
                            gvIndex.DeleteSelectedRows();
                        else
                        {
                            //fpd.delete(keydetail);
                            _lstBarcode.Add(gvIndex.GetRowCellValue(gvIndex.FocusedRowHandle, "NoFP").ToString());
                            gvIndex.DeleteSelectedRows();
                        }
                    }
                    else
                    {
                        DialogResult tmp = MessageBox.Show("Please delete Product in FinanceProduct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        if(tmp  == DialogResult.OK)
                        {
                            tabFinance.SelectedTabPage = pageFinanceDetail;
                        }
                    }

                
                   
                }
                else
                {
                    MessageBox.Show("Please choose column.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else if(tabFinance.SelectedTabPage == pageFinanceDetail)
            {

                int index = 0;
                if (gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "BARCODE") != null)
                {
                    if (_add)
                        gvDetail.DeleteSelectedRows();
                    else
                    {   
                        index = gvDetail.FocusedRowHandle;
                        _lstBarcode.Add(gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "BARCODE").ToString());
                        DialogResult tmp = MessageBox.Show("Are you sure delete product!", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (tmp == DialogResult.Yes)
                        {
                            
                            gvDetail.DeleteSelectedRows();
                        }
                        else
                        {
                            return;
                        }
                       
                    }
                    if (gvDetail.RowCount == 0)
                    {
                        gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "No", 1);
                    }
                    else
                    {
                        for (int i = 0; i < gvDetail.RowCount; i++)
                        {
                            gvDetail.FocusedRowHandle = i;
                            gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "STT", i + 1);
                        }
                    }
                    gvDetail.FocusedRowHandle = index;
                }
                else
                {
                    MessageBox.Show("Please choose column.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

        }
      

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveInformation();
            _add = false;
            _edit = false;
            gvDetail.OptionsBehavior.Editable = false;
            contextMenuDetail.Enabled = false;
            tabFinance.TabPages[0].PageEnabled = true;
            showHideControls(true);
            _Control(false);
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            _add = false;
            _edit = false;
            showHideControls(true);
            _reset();
            contextMenuDetail.Enabled = false;
            _Control(false);
            exportInformation();
            tabFinance.TabPages[0].PageEnabled = true;
            tabFinance.SelectedTabPage = pageFinancyPaper;
            gvDetail.OptionsBehavior.Editable = false;

        }
        

        private void btnExport_Click(object sender, EventArgs e)
        {
            Print_report( "PURCHASE_ENTRY_FORM");
        }
        private void Print_report( string _title)
        {
            if (_keyFin != null)
            {
                Form frm = new Form();
                CrystalReportViewer rpv = new CrystalReportViewer();
                rpv.ShowGroupTreeButton = false;
                rpv.ShowParameterPanelButton = false;
                rpv.ToolPanelView = ToolPanelViewType.None;

                TableLogOnInfo Information;
                ReportDocument document = new ReportDocument();
                string path = System.Windows.Forms.Application.StartupPath;
                document.Load("..\\..\\ReportPurchaseEntry.rpt");
                Information = document.Database.Tables[0].LogOnInfo;
                Information.ConnectionInfo.ServerName = "MSI";
                Information.ConnectionInfo.DatabaseName = "Product_Managerment";
                Information.ConnectionInfo.UserID = "admin";
                Information.ConnectionInfo.Password = "999999999";
                try
                {
                    document.SetParameterValue("Key", "{" + _keyFin.ToString() + "}");
                    rpv.Dock = DockStyle.Fill;
                    rpv.ReportSource = document;
                    frm.Controls.Add(rpv);
                    rpv.Refresh();
                    frm.Text = _title;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString());
                }
            }

            else
            {
                MessageBox.Show("Không có dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvDetail.OptionsBehavior.Editable)
            {
                _isImport = false;
                if(e.KeyData == Keys.Down)
                {
                    if(int.Parse(gvDetail.FocusedRowHandle.ToString()) == (gvDetail.RowCount - 1))
                    {
                        if(gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "NameProduct") != null)
                        {
                            gvDetail.AddNewRow();
                        }
                    }
                }if(e.KeyData == Keys.Up)
                {
                    if (int.Parse(gvDetail.FocusedRowHandle.ToString()) == (gvDetail.RowCount - 1))
                    {
                        if (gvDetail.FocusedValue == null && gvDetail.RowCount > 1|| (gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "NameProduct") ==  null && gvDetail.RowCount > 1)){
                            gvDetail.DeleteSelectedRows();
                        }
                    }
                }
                else
                {
                    e.Handled = false;
                }
            }
        }

        private void gvIndex_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.FieldName == "Status")
            {
                if (e.CellValue.ToString() == "1")

                    e.DisplayText = "Incomplete";
                else
                    e.DisplayText = "Complete";

                
            }
        }

        private void gvDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!_isImport)
            {

                if(e.Column.FieldName == "BARCODE")
                {
                    if (gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "BARCODE").ToString().IndexOf(".") == 0)
                    {
                        _isImport = true;
                        frmList _popDm = new frmList(gvDetail, gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "BARCODE").ToString());
                        _popDm.ShowDialog();

                    }
                    else
                    {
                        Product _prot = _pro.getItem(e.Value.ToString());
                        if (_prot != null)
                        {
                            if (_pro.checkExist(_prot.BARCODE))
                            {
                                List<string> list = new List<string>();
                                if (gvDetail.RowCount > 1)
                                {

                                    for (int i = 0; i < gvDetail.RowCount - 1; i++)
                                    {
                                        list.Add(gvDetail.GetRowCellValue(i, "BARCODE").ToString());
                                    }
                                    if (list.Find(x => x.Equals(e.Value.ToString())) != null)
                                    {
                                        MessageBox.Show("Id is a valid! Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;

                                    }
                                    else
                                    {
                                        gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "NameProduct", _prot.NameProduct);
                                        gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "Unit", _prot.Unit);
                                        gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "Quantily", 1);
                                        gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "Price", _prot.Price);
                                        gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "Amount", _prot.Price);
                                        gvDetail.UpdateTotalSummary();
                                    }
                                }
                                else
                                {
                                    gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "NameProduct", _prot.NameProduct);
                                    gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "Unit", _prot.Unit);
                                    gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "Quantily", 1);
                                    gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "Price", _prot.Price);
                                    gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "Amount", _prot.Price);
                                    gvDetail.UpdateTotalSummary();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Id is a valid! Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        else
                        {

                            MessageBox.Show("Id is a valid! Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        gvDetail.RefreshData();

                    }
                }

                if(e.Column.FieldName == "Quantily")
                {
                    if (gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "NameProduct") != null)
                    {
                        double _no = double.Parse(e.Value.ToString());
                
                        if(_no != 0)
                        {
                            Product _prot = _pro.getItem(gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "BARCODE").ToString());
                            if(gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "Price").ToString() != null)
                            {
                                double _value = double.Parse(gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "Price").ToString());
                                gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "Amount", _value * _no);
                               


                            }
                            else
                            {
                                gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "Amount", 0);
                            }
                            gvDetail.UpdateTotalSummary();
                        }
                        else
                        {
                            MessageBox.Show("The number of assets cannot be equal to 0", "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                    gvDetail.RefreshData();
                }
            }
        }

        private void gvIndex_DoubleClick(object sender, EventArgs e)
        {
            if(gvIndex.RowCount > 0)
            {
                tabFinance.SelectedTabPage = pageFinanceDetail;
            }
            exportInformation();


        }

        private void tabFinance_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(_edit ==  false && tabFinance.SelectedTabPage == pageFinanceDetail)
            {
                gvDetail.OptionsBehavior.Editable = false;
            }
        }

        private void dtSince_ValueChanged(object sender, EventArgs e)
        {
            if(dtSince.Value > dtToDate.Value)
            {
                MessageBox.Show("Date not a valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dtToDate_Leave(object sender, EventArgs e)
        {
            if(dtSince.Value > dtToDate.Value)
            {
                MessageBox.Show("Date not a valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _lstF = fp.getList(1, dtSince.Value, dtToDate.Value.AddDays(1), cbStock.SelectedValue.ToString());
                _bdfinance.DataSource = _lstF;
            }
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            if(dtSince.Value > dtToDate.Value)
            {
                MessageBox.Show("Date not a valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dtSince_Leave(object sender, EventArgs e)
        {
            if (dtSince.Value > dtToDate.Value)
            {
                MessageBox.Show("Date not a valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _lstF = fp.getList(1, dtSince.Value, dtToDate.Value.AddDays(1), cbStock.SelectedValue.ToString());
                _bdfinance.DataSource = _lstF;
            }
        }
        bool cal(Int32 _with, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _with ? _with : _View.IndicatorWidth;
            return true;
        }

        private void gvIndex_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gvIndex.IsGroupRow(e.RowHandle))
            {
                if (e.Info.IsRowIndicator)
                {
                    if(e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1;
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); 
                    }
                    SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                    Int32 _width = Convert.ToInt32(_size.Width) +20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_width, gvIndex); }));
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1));
                SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _width = Convert.ToInt32(_size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_width, gvIndex); }));
            }
        }

        private void gvDetail_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {

            if (!gvDetail.IsGroupRow(e.RowHandle))
            {
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1;
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                    SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                    Int32 _width = Convert.ToInt32(_size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_width, gvDetail); }));
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1));
                SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _width = Convert.ToInt32(_size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_width, gvDetail); }));
            }

        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel 2007 or higher(.xlsx)|*.xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                gvDetail.ExportToXlsx(saveFile.FileName);
            }
        }

        private void ExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF file(.pdf)|*.pdf";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                gvDetail.ExportToPdf(saveFile.FileName);
            }
        }

        private void ExportWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Word 2007 or higher(.docx)|*.docx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                gvDetail.ExportToDocx(saveFile.FileName);
            }
        }

        private void deleteSelected_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "BARCODE") != null)
            {
                if (_add)
                {
  
                    gvDetail.DeleteSelectedRows();
                   //fpd.delete(gvDetail.Cur);

                }
                 
                else
                {
                    index = gvDetail.FocusedRowHandle;
                    _lstBarcode.Add(gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, "BARCODE").ToString());
                    gvDetail.DeleteSelectedRows();
                }
                if (gvDetail.RowCount == 0)
                {
                    gvDetail.AddNewRow();
                    gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "No", 1);
                }
                else
                {
                    for (int i = 0; i < gvDetail.RowCount; i++)
                    {
                        gvDetail.FocusedRowHandle = i;
                        gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "STT", i + 1);
                    }
                }
                gvDetail.FocusedRowHandle = index;
            }
            else
            {
                MessageBox.Show("Please selected need delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            _lstBarcode.Clear();
            for (int i = gvDetail.RowCount - 1; i >= 0; i--)
            {
                _lstBarcode.Add(gvDetail.GetRowCellValue(i, "BARCODE").ToString());
                gvDetail.DeleteRow(i);
            }
            gvDetail.AddNewRow();
            gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, "No", 1);
        }
    }
    }
