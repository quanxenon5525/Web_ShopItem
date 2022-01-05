using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class SYS_SEQUENCES
    {
        Entities db;

        public SYS_SEQUENCES()
        {
            db = Entities.CreateEntities();
        }
        public SYS_SEQUENCE getItem(string seqname)
        {
            return db.SYS_SEQUENCE.FirstOrDefault(x => x.SEQNAME == seqname);
        }
        public void add(SYS_SEQUENCE sequence)
        {
            try
            {
                db.SYS_SEQUENCE.Add(sequence);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void update(SYS_SEQUENCE sequence)
        {
            var seq = db.SYS_SEQUENCE.FirstOrDefault(x => x.SEQNAME ==  sequence.SEQNAME);
            seq.SEQVALUE = sequence.SEQVALUE + 1;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
    }
}
