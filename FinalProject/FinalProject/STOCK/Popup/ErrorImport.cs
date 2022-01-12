using BussinessLayer;
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
    public partial class ErrorImport : DevExpress.XtraEditors.XtraForm
    {
        public ErrorImport()
        {
            InitializeComponent();
        }
        List<errExport> _err;

        public ErrorImport(List<errExport> err)
        {
            InitializeComponent();
            this._err = err;

        }
      private void ErrorImport_Load(object sender, EventArgs e)
        {
           
        }
    }
}