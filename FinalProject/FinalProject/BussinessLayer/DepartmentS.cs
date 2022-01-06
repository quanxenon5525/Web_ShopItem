using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DepartmentS
    {
        Entities db;
        public DepartmentS()
        {
            db = Entities.CreateEntities();
        }
        public Department getItem(string id)
        {
            return db.Departments.FirstOrDefault(x => x.IdDepartment == id);
        }
        public List<Department> getAll()
        {
            return db.Departments.ToList();
        }
        public List<Department> getAll(string id)
        {
            return db.Departments.Where(x => x.IdCompany == id).ToList();
        }
        public List<Department> getStockByCompany(string id)
        {   
          
           return db.Departments.Where(x => x.IdCompany == id && x.STOCK == true).ToList();
         
        }
        public void add(Department dept)
        {
            try
            {
                db.Departments.Add(dept);
                db.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception("Error"+ ex.Message);
            }
        }
        public void update(Department dept)
        {
            Department _dept = db.Departments.FirstOrDefault(x => x.IdDepartment == dept.IdDepartment);
            _dept.IdCompany = dept.IdCompany;
            _dept.NameDepartment = dept.NameDepartment;
            _dept.Phone = dept.Phone;
            _dept.Fax = dept.Fax;
            _dept.Email = dept.Email;
            _dept.Address = dept.Address;
            _dept.DISABLED = dept.DISABLED;
            _dept.STOCK = dept.STOCK;
            _dept.Syntax = dept.Syntax;
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
            Department _dept = db.Departments.FirstOrDefault(x => x.IdDepartment == id);
            if(_dept != null)
            {
                       _dept.DISABLED = true;
                        try
                        {
                        db.Departments.Remove(_dept);
                            db.SaveChanges();
                        }
                        catch(Exception ex)
                        {
                            throw new Exception("Error" + ex.Message);
                        }
                }
            }
        }
    }

