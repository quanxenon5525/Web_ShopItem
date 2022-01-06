using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class CustomerS
    {
        Entities db;
        public CustomerS()
        {
            db = Entities.CreateEntities();
        }

        public Customer getItem(string id)
        {
            return db.Customers.FirstOrDefault(x => x.idCustom == id);
        }
        public List<Customer> getAll()
        {
            return db.Customers.ToList();
        }
        public List<Customer> getAll(string id)
        {
            return db.Customers.Where(x => x.idCustom == id).ToList();
        }
        public void add(Customer sup)
        {
            try
            {
                db.Customers.Add(sup);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void update(Customer dept)
        {
            Customer _dept = db.Customers.FirstOrDefault(x => x.idCustom == dept.idCustom);
            _dept.FullName = dept.FullName;
            _dept.Phone = dept.Phone;
            _dept.Email = dept.Email;
            _dept.Address = dept.Address;
            _dept.MST = dept.MST;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void delete(string id)
        {
            Customer _dept = db.Customers.FirstOrDefault(x => x.idCustom == id);
            try
            {
                db.Customers.Remove(_dept);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }


        public List<Customer> getList()
        {
            return db.Customers.ToList();
        }
    }
}

