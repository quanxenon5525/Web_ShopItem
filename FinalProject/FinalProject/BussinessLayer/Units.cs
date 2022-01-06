using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Units
    {
        Entities db;
        public Units()
        {
            db = Entities.CreateEntities();
        }
        public Unit getItem(int id)
        {
            return db.Units.FirstOrDefault(x => x.IdUnit == id);
        }
        public List<Unit> getAll()
        {
            return db.Units.ToList();
        }
        public void add(Unit comp)
        {
            try
            {
                db.Units.Add(comp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void update(Unit comp)
        {
            Unit _comp = db.Units.FirstOrDefault(x => x.IdUnit == comp.IdUnit);
            _comp.NameUnit = comp.NameUnit;
        
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
            Unit compt = db.Units.FirstOrDefault(x => x.IdUnit == id);
            try
            {
                db.Units.Remove(compt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
    }


}
