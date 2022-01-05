using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Statistical
    {

        Entities db;
        public Statistical()
        {
            db = Entities.CreateEntities();
        }
        public List<objGroupProduct> StatisticalGroupProduct()
        {
            objGroupProduct grouppro;
            List<objGroupProduct> lstStatistical = new List<objGroupProduct>();
            DateTime firstdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lst = db.FN_TURNOVER_MONTHLY(firstdate, DateTime.Now).ToList();
            foreach(var item in lst)
            {
                    grouppro = new objGroupProduct();
                    grouppro.IdGroupProduct = (int)item.IdGroupProduct;
                    grouppro.NameGProduct = item.NameGProduct;
                    grouppro.Amount = (double)item.Amount;
                lstStatistical.Add(grouppro);
            }
            var tmp = lstStatistical.Count;
            return lstStatistical;
            //return null;


        }
    }
}
