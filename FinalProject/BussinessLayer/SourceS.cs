using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class SourceS
    {
        Entities db;



        public SourceS()
        {
            db = Entities.CreateEntities();
        }
        public Source getItem(int id)
        {
            return db.Sources.FirstOrDefault(x => x.IdSource == id);
        }
        public List<Source> getAll()
        {
            return db.Sources.ToList();
        }
        public void add(Source comp)
        {
            try
            {
                db.Sources.Add(comp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void update(Source comp)
        {
            Source _comp = db.Sources.FirstOrDefault(x => x.IdSource == comp.IdSource);
           
            _comp.NameSource = comp.NameSource;
            _comp.DISABLED = comp.DISABLED;

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
            Source compt = db.Sources.FirstOrDefault(x => x.IdSource == id);
            if(compt != null)
            {
                compt.DISABLED = true;
                try
                {
                    db.Sources.Remove(compt);
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
