using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DealDetailS
    {

        Entities db;
        public DealDetailS()
        {
            db = Entities.CreateEntities();
        }
        public OrderDetail getItem(int id)
        {
            return db.OrderDetails.FirstOrDefault(x => x.idDetail == id);
        }
        public List<OrderDetail> getAll()
        {
            return db.OrderDetails.ToList();
        }
        public void add(OrderDetail comp)
        {
            try
            {
                db.OrderDetails.Add(comp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public List<objDeal> GetListByDetail(int idOrder)
        {
            var lst = db.OrderDetails.Where(x => x.OrderId == idOrder).ToList();
            List<objDeal> detail = new List<objDeal>();
            objDeal obj;
            foreach (var item in lst)
            {
                obj = new objDeal();
                obj.idOrder = (int)item.OrderId;
                var h = db.Products.FirstOrDefault(x => x.BARCODE == item.ProductId);
                if (h != null)
                {
                    obj.NameProduct = h.NameProduct;

                }

                obj.Quantity = item.Quantity;
                detail.Add(obj);
            }
            return detail;
        }

        public void update(OrderDetail comp)
        {
            OrderDetail _comp = db.OrderDetails.FirstOrDefault(x => x.idDetail == comp.idDetail);
            _comp.OrderId = _comp.OrderId;
            _comp.ProductId = _comp.ProductId;
            _comp.Quantity = _comp.Quantity;
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void delete(int id)
        {
            OrderDetail compt = db.OrderDetails.FirstOrDefault(x => x.idDetail == id);
            if (compt != null)
            {
                try
                {
                    db.OrderDetails.Remove(compt);
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
    

