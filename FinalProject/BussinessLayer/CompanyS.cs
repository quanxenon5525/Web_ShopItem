using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
   public class CompanyS
    {
        Entities db;
        public CompanyS()
        {
            db = Entities.CreateEntities();
        }
        public Company getItem(string id)
        {
            return db.Companies.FirstOrDefault(x => x.IdCompany == id);
        }
        public List<Company> getAll()
        {
            return db.Companies.ToList();
        }
        public void add(Company comp)
        {
            try
            {
                db.Companies.Add(comp);
                db.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void update(Company comp)
        {
            Company _comp = db.Companies.FirstOrDefault(x => x.IdCompany == comp.IdCompany);
            _comp.NameCompany = comp.NameCompany;
            _comp.Phone = comp.Phone;
            _comp.Fax = comp.Fax;
            _comp.Email = comp.Email;
            _comp.Address = comp.Address;
            _comp.DISABLED = comp.DISABLED;
            try
            {
                db.SaveChanges();

            }catch(Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void delete(string id)
        {
            Company compt = db.Companies.FirstOrDefault(x => x.IdCompany == id);
            if(compt != null)
            { compt.DISABLED = true;
            try
            {
                db.Companies.Remove(compt);
                db.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            }
           
        }
    }
}
