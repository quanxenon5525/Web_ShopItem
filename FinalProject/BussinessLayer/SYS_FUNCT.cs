using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class SYS_FUNCT
    {
        Entities db;
        public SYS_FUNCT()
        {
            db = Entities.CreateEntities();
        }
        public List<SYS_FUNC> getParent()
        {
            return db.SYS_FUNC.Where(x => x.ISGROUP == true && x.MENU == true).OrderBy(s => s.SORT).ToList();
        }
        public List<SYS_FUNC> getChild(string parent)
        {
            return db.SYS_FUNC.Where(x => x.ISGROUP == false && x.MENU == true && x.PARENT == parent).OrderBy(s => s.SORT).ToList();
        }
    }
}
