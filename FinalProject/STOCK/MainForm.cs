using BussinessLayer;
using DataLayer;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
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
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        SYS_FUNCT _func;
        Statistical _stastis;

        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _func = new SYS_FUNCT();
            _stastis = new Statistical();
            leftMenu();
            Series _seri = new Series("Statistical", ViewType.Bar3D);


            var list = _stastis.StatisticalGroupProduct();
           foreach(var item in list)
            {
                _seri.Points.Add(new SeriesPoint(item.NameGProduct, item.Amount));
            }

            chartTurnover.Series.Add(_seri);
            _seri.Label.TextPattern = "{A}:{VP: p0}";

        }
        private void btnHome_Click(object sender, EventArgs e)
        {

        }
        void leftMenu()
        {
            int i = 0;
            var _lsparent = _func.getParent();
            foreach(var _pr in _lsparent)
            {
                NavBarGroup navbargroup = new NavBarGroup(_pr.DESCRIPTION);
                navbargroup.Tag = _pr.FUNC_CODE;
                navbargroup.Name = _pr.FUNC_CODE;
                navbargroup.ImageOptions.LargeImageIndex = i;
                i++;
                navMain.Groups.Add(navbargroup);

                var _lsChild = _func.getChild(_pr.FUNC_CODE);
                foreach(var _ch in _lsChild)
                {
                    NavBarItem navbarItem = new NavBarItem(_ch.DESCRIPTION);
                    navbarItem.Tag = _ch.FUNC_CODE;
                    navbarItem.Name = _ch.FUNC_CODE;
                    navbarItem.ImageOptions.SmallImageIndex = 0;
                    navbargroup.ItemLinks.Add(navbarItem);
                }
                navMain.Groups[navbargroup.Name].Expanded = true;
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void navMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string func_code = e.Link.Item.Tag.ToString();

            switch (func_code)
            {
                case "DEPARTMENT":
                    {
                        frmDepartment frm = new frmDepartment();
                        frm.ShowDialog();
                        break;
                    }
                case "COMPANY":
                    {
                        frmCompany frm = new frmCompany();
                        frm.ShowDialog();
                        break;
                    }
                case "SUPPLIER":
                    {
                        frmSupplier frm = new frmSupplier();
                        frm.ShowDialog();
                        break;
                    }
                case "UNIT":
                    {
                        frmUnit frm = new frmUnit();
                        frm.ShowDialog();
                        break;
                    }
                case "SOURCE":
                    {
                        frmSource frm = new frmSource();
                        frm.ShowDialog();
                        break;
                    }
                case "GROUP PRODUCT":
                    {
                        frmGroupProduct frm = new frmGroupProduct();
                        frm.ShowDialog();
                        break;
                    }
                case "PRODUCT":
                    {
                        frmProduct frm = new frmProduct();
                        frm.ShowDialog();
                        break;
                    }
                case "PURCHASE ENTRY FORM":
                    {
                        frmPurchaseEntry frm = new frmPurchaseEntry();
                        frm.ShowDialog();
                        break;
                    }
                case "CUSTOMER":
                    {
                        frmCustomer frm = new frmCustomer();
                        frm.ShowDialog();
                        break;
                    }
                case "PURCHASE OUTPUT FORM":
                    {
                        frmExportProduct frm = new frmExportProduct();
                        frm.ShowDialog();
                        break;
                    }
                case "DealOrder":
                    {
                        fmDeal frm = new fmDeal();
                        frm.ShowDialog();
                        break;
                    }
            }
        }
    }
}