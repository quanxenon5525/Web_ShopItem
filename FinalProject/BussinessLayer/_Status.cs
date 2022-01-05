using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
   public  class _Status
    {
        public int _value { set; get; }
        public string _display { set; get;}
        public _Status()
        {

        }
        public _Status(int _val, string _dis)
        {
            this._value = _val;
            this._display = _dis;
        }
        public static List<_Status> getList()
        {
            List<_Status> lst = new List<_Status>();
            _Status[] collect = new _Status[2]
            {
                new _Status(1,"Incomplete"),
                new _Status(2,"Complete")
        };
            lst.AddRange(collect);
            return lst;
        }
    }
}
