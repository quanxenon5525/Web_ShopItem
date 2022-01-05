using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class SupplierS
    {
        Entities db;
        public SupplierS()
        {
            db = Entities.CreateEntities();
        }
        public Supplier getItem(string id)
        {
            return db.Suppliers.FirstOrDefault(x => x.IdSupplier == id);
        }
        public List<Supplier> getAll()
        {
            return db.Suppliers.ToList();
        }
        public List<Supplier> getAll(string id)
        {
            return db.Suppliers.Where(x => x.IdSupplier == id).ToList();
        }
        public void add(Supplier sup)
        {
            try
            {
                db.Suppliers.Add(sup);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void update(Supplier dept)
        {
            Supplier _dept = db.Suppliers.FirstOrDefault(x => x.IdSupplier == dept.IdSupplier);
            _dept.NameSupplier = dept.NameSupplier;
            _dept.Phone = dept.Phone;
            _dept.Fax = dept.Fax;
            _dept.Email = dept.Email;
            _dept.Address = dept.Address;
            _dept.DISABLED = dept.DISABLED;
            _dept.CREATED_DATE = dept.CREATED_DATE;
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
            Supplier _dept = db.Suppliers.FirstOrDefault(x => x.IdSupplier == id);
            _dept.DISABLED = true;
            try
            {
                db.Suppliers.Remove(_dept);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
    }
}

