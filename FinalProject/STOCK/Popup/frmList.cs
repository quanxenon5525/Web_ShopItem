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

namespace STOCK.Popup
{
    public partial class frmList : DevExpress.XtraEditors.XtraForm
    {
        public frmList()
        {
            InitializeComponent();
        }
        public frmList(DevExpress.XtraGrid.Views.Grid.GridView gvDetail, string tmp)
        {
            InitializeComponent();
            this._tmp = tmp;
            this._gvDetail = gvDetail;
        }
        string _tmp;
        DevExpress.XtraGrid.Views.Grid.GridView _gvDetail;
        FinancyDetailS _fpdt;
        ProductS _product;

        private void frmList_Load(object sender, EventArgs e)
        {
            _fpdt = new FinancyDetailS();
            _product = new ProductS();
            if (_tmp.Trim().Length == 1)

                gcIndex.DataSource = _product.getAll();
            else
                gcIndex.DataSource = _product.getListByKeyWord(_tmp.Substring(1, _tmp.Length - 1).TrimStart().ToString());
                gvIndex.OptionsBehavior.Editable = false;
        }
        void Insert()
        {
            int[] _selectRow = gvIndex.GetSelectedRows();
            List<string> _selected = new List<string>();
            foreach (int item in _selectRow)
            {
                _selected.Add(gvIndex.GetRowCellValue(item, "BARCODE").ToString());

            }
            List<errExport> _err = new List<errExport>(); 
            List<string> _valid = new List<string>();
            List<string> _exit = new List<string>();

            if (_gvDetail.RowCount > 1)
            {
                if (_gvDetail.GetRowCellValue(_gvDetail.RowCount - 1, "NameProduct") != null)
                {
                    for (int i = 0; i < _gvDetail.RowCount; i++)

                        _exit.Add(_gvDetail.GetRowCellValue(i, "BARCODE").ToString());

                }
                else
                {
                    for (int i = 0; i < _gvDetail.RowCount - 1; i++)
                    {
                        _exit.Add(_gvDetail.GetRowCellValue(i, "BARCODE").ToString());
                    }
                }
            }

            //check 
                for (int i = 0; i < _selected.Count; i++)
                {
                    Product tmp = _product.getItem(_selected[i]);
 
                    if (_exit.Contains(_selected[i]) == true)
                    {
                        errExport err = new errExport();
                        err._barcode = _selected[i];
                        err._quantity = 1;
                        err._errcode = "ID is avlid";
                        _err.Add(err);
                        continue;
                    }
                    else
                    {
                        _valid.Add(_selected[i]);
                        continue;
                    }
                }

                //import  
                foreach (string _item in _valid)
                {
                    Product _pro = _product.getItem(_item);
                    if (_gvDetail.RowCount > 1)
                    {
                        int examp = _gvDetail.RowCount;
                        _gvDetail.SelectRow(examp - 1);

                        if (_gvDetail.GetRowCellValue(_gvDetail.FocusedRowHandle, "NameProduct") == null)
                        {
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "No", examp);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "BARCODE", _pro.BARCODE);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Unit", _pro.Unit);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "NameProduct", _pro.NameProduct);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Quantily", 1);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Price", _pro.Price);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Amount", _pro.Price);

                        }
                        else
                        {
                            _gvDetail.AddNewRow();
                            _gvDetail.SelectRow(examp);
                            examp++;
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "No", examp);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "BARCODE", _pro.BARCODE);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Unit", _pro.Unit);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "NameProduct", _pro.NameProduct);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Quantily", 1);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Price", _pro.Price);
                            _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Amount", _pro.Price);


                        }
                    }
                    else
                    {
                        if(_gvDetail.RowCount == 0)
                        
                            _gvDetail.AddNewRow();
                            int examp = _gvDetail.RowCount;
                            _gvDetail.SelectRow(examp - 1);
                            if (_gvDetail.GetRowCellValue(_gvDetail.FocusedRowHandle, "NameProduct") == null)
                            {
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "No", examp);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "BARCODE", _pro.BARCODE);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Unit", _pro.Unit);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "NameProduct", _pro.NameProduct);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Quantily", 1);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Price", _pro.Price);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Amount", _pro.Price);

                            }
                            else
                            {
                                _gvDetail.AddNewRow();
                                _gvDetail.SelectRow(examp);
                                examp++;


                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "No", examp);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "BARCODE", _pro.BARCODE);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Unit", _pro.Unit);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "NameProduct", _pro.NameProduct);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Quantily", 1);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Price", _pro.Price);
                                _gvDetail.SetRowCellValue(_gvDetail.FocusedRowHandle, "Amount", _pro.Price);

                            }
                        }
                    }
                    _gvDetail.AddNewRow();
                    _gvDetail.SelectRow(_gvDetail.RowCount - 1);
                    _gvDetail.DeleteSelectedRows();
                    _gvDetail.RefreshData();
                    if(_err.Count > 0)
                    {
                        ErrorImport _errpop = new ErrorImport(_err);
                        _errpop.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }

                
       
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
