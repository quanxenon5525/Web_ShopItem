using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
   public class DealS
    {
        Entities db;
        public DealS()
        {
            db = Entities.CreateEntities();
        }
        public Order getItem(int id)
        {
            return db.Orders.FirstOrDefault(x => x.idOrder == id);
        }
        public List<Order> getAll()
        {
            return db.Orders.ToList();
        }
        public void add(Order comp)
        {
            try
            {
                db.Orders.Add(comp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void update(Order comp)
        {
            Order _comp = db.Orders.FirstOrDefault(x => x.idOrder == comp.idOrder);
            var h = db.Products.Where(x => x.BARCODE == _comp.idCus);
             
            
            _comp.NameProduct = comp.NameProduct;
            _comp.Status = comp.Status;
            _comp.CreateOrder = comp.CreateOrder;
            _comp.idCus = comp.idCus;
            _comp.pay = comp.pay;
    
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
            Order compt = db.Orders.FirstOrDefault(x => x.idOrder == id);
            if (compt != null)
            {
                try
                {
                    db.Orders.Remove(compt);
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

