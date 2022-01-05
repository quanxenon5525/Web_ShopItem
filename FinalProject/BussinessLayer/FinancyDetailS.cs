using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class FinancyDetailS
    {
        Entities db;
        public FinancyDetailS()
        {
            db = Entities.CreateEntities();
        }
        public FinancialPaperDetail getItem(Guid id)
        {
            return db.FinancialPaperDetails.FirstOrDefault(x => x.KeyDetail == id);
        }
        public List<FinancialPaperDetail> getList()
        {
            return db.FinancialPaperDetails.ToList();
        }
        public List<FinancialPaperDetail> getList(Guid id)
        {
            return db.FinancialPaperDetails.Where(x => x.KeyDetail == id).ToList();
        }
        public List<objFinacyParperDetail> getListByKeyDetail(Guid key)
        {
            var lst = db.FinancialPaperDetails.Where(x => x.KeyFinace == key).ToList();
            List<objFinacyParperDetail> lsdt = new List<objFinacyParperDetail>();
            objFinacyParperDetail obj;
            foreach (var item in lst)
            {
                obj = new objFinacyParperDetail();
                obj.key = item.KeyFinace;
                obj.KeyDetail = item.KeyDetail;
                obj.BARCODE = item.BARCODE;
                var h = db.Products.FirstOrDefault(x => x.BARCODE == item.BARCODE);
                if(h != null)
                {
                    obj.NameProduct = h.NameProduct;
                    obj.Unit = h.Unit;
                }

                obj.Discount = item.Discount;
                obj.Quantily = item.Quantily;
                obj.Price = item.Price;
                obj.Amount = item.Amount;
                obj.No = item.No;
                obj.Date = item.Date;
                lsdt.Add(obj);


            }
            return lsdt;
        }

        public FinancialPaperDetail add(FinancialPaperDetail dept)
        {
            try
            {
                db.FinancialPaperDetails.Add(dept);
                db.SaveChanges();
                return dept;
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public FinancialPaperDetail update(FinancialPaperDetail dept)
        {
            FinancialPaperDetail _dept = db.FinancialPaperDetails.FirstOrDefault(x => x.KeyDetail == dept.KeyDetail);
            _dept.KeyFinace = dept.KeyFinace;
            _dept.BARCODE = dept.BARCODE;
            _dept.Quantily = dept.Quantily;
            _dept.Price = dept.Price;
            _dept.Amount = dept.Amount;
            _dept.Date = dept.Date;
            _dept.No = dept.No;
         
          
            try
            {
                db.SaveChanges();
                return dept;
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void delete(string id)
        {
            FinancialPaperDetail _dept = db.FinancialPaperDetails.FirstOrDefault(x => x.BARCODE == id);
            if (_dept != null)
            {
                try
                {
                    db.FinancialPaperDetails.Remove(_dept);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error" + ex.Message);
                }
            }

        }
        public void deleteAll(Guid id)
        {
            FinancialPaperDetail _dept = db.FinancialPaperDetails.FirstOrDefault(x => x.KeyFinace == id);
            if (_dept != null)
            {
                try
                {
                    db.FinancialPaperDetails.Remove(_dept);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error" + ex.Message);
                }
            }

        }
    }
}
