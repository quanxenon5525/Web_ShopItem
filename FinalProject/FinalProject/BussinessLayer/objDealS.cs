using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
   public class objDealS
    {
        public int idOrder { get; set; }
        public string NameProduct { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> CreateOrder { get; set; }
        public string idCus { get; set; }
        public string pay { get; set; }
        public string nameCustomer { set; get; }
    }
}
