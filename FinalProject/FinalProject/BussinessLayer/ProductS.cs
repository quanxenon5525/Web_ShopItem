using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
   public class ProductS
    {
        Entities db;
        public ProductS()
        {
            db = Entities.CreateEntities();
        }
        public Product getItem(string id)
        {
            return db.Products.FirstOrDefault(x => x.BARCODE== id);
        }
        public List<Product> getAll()
        {
            return db.Products.ToList();
        }
        public List<Product> getListByGroup(int id)
        {
            return db.Products.Where(x => x.IdGroupProduct == id).OrderBy(o => o.CREATE_DATE).ToList();
        }
        public List<objProduct> getListByGroupFull(int id)
        {
            var list = db.Products.Where(x => x.IdGroupProduct == id).OrderBy(o => o.CREATE_DATE).ToList();
            List<objProduct> listobj = new List<objProduct>();
            objProduct _pro;
            foreach(var item in list)
            {
                _pro = new objProduct();
                _pro.BARCODE = item.BARCODE;
                _pro.NameProduct = item.NameProduct;
                _pro.NameAT = item.NameAT;
                _pro.IdGroupProduct = item.IdGroupProduct;
                var group = db.GroupProducts.FirstOrDefault(x => x.IdGroupProduct == item.IdGroupProduct);
                _pro.NameGProduct = group.NameGProduct;
                _pro.IdSupplier = item.IdSupplier;
                var supplier_name = db.Suppliers.FirstOrDefault(x => x.IdSupplier == item.IdSupplier);
                _pro.NameSupplier = supplier_name.NameSupplier;
                _pro.IdSource = item.IdSource;
                var _source = db.Sources.FirstOrDefault(x => x.IdSource == item.IdSource);
                _pro.NameSource = _source.NameSource;
                _pro.Unit = item.Unit;
                _pro.Price = item.Price;
                _pro.Note = item.Note;
                listobj.Add(_pro);


            }
            return listobj;
        }
        public List<Product> getListByKeyWord(string keyword)
        {
            return db.Products.Where(x => x.NameProduct.Contains(keyword)).ToList();
        }


        public Product add(Product dept)
        {
            try
            {
                db.Products.Add(dept);
                db.SaveChanges();
                return dept;
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public Product update(Product dept)
        {
            Product _dept = db.Products.FirstOrDefault(x => x.BARCODE == dept.BARCODE);

            _dept.NameProduct = dept.NameProduct;
            _dept.NameAT = dept.NameAT;
            _dept.Unit = dept.Unit;
            _dept.Price = dept.Price;
            _dept.IdSupplier = dept.IdSupplier;
            _dept.IdSource = dept.IdSource;
            _dept.DISABLED = dept.DISABLED;
            _dept.IdGroupProduct = dept.IdGroupProduct;
            _dept.Note = dept.Note;
            _dept.CREATE_DATE = dept.CREATE_DATE;
            _dept.CREATE_BY = dept.CREATE_BY;

            try
            {
                db.SaveChanges();
                return _dept;
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

     

        public void delete(string id)
        {
            Product _dept = db.Products.FirstOrDefault(x => x.BARCODE == id);
            _dept.DISABLED = true;
            try
            {
                db.Products.Remove(_dept);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        public bool checkExist(string bARCODE)
        {
            var barcode = db.Products.Where(x => x.BARCODE == bARCODE);
            if (barcode != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
