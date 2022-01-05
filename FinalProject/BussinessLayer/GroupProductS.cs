using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
   public class GroupProductS
    {
        Entities db;

        public GroupProductS()
        {
            db = Entities.CreateEntities();
        }
        public GroupProduct getItem(int id)
        {
            return db.GroupProducts.FirstOrDefault(x => x.IdGroupProduct == id);
        }
        public List<GroupProduct> getAll()
        {
            return db.GroupProducts.ToList();
        }
        public void add(GroupProduct comp)
        {
            try
            {
                db.GroupProducts.Add(comp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void update(GroupProduct comp)
        {
            GroupProduct _comp = db.GroupProducts.FirstOrDefault(x => x.IdGroupProduct == comp.IdGroupProduct);
            _comp.NameGProduct = comp.NameGProduct;
            _comp.DISABLED = comp.DISABLED;
            _comp.Note = comp.Note;

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
            GroupProduct compt = db.GroupProducts.FirstOrDefault(x => x.IdGroupProduct == id);
            if (compt != null)
            {
                compt.DISABLED = true;
                try
                {
                    db.GroupProducts.Remove(compt);
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

