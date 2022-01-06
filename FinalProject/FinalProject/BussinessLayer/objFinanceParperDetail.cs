using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class objFinacyParperDetail
    {
        public System.Guid KeyDetail { get; set;}
        public Nullable<System.Guid> key { get; set; }

        public string BARCODE { get; set;}
        public string NameProduct { get; set;}
        public string Unit { get; set; }
        public Nullable<int> Quantily { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<int> No { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Discount { get; set; }

    }
}
