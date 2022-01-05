using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class EAN13
    {
        public EAN13()
        {

        }
        public static string BuildEAN13(string code)
        {
            int Sum = 0;
            int Digit = 0;

            for(int i = code.Length; i >= 1; i--)
            {
                Digit = Convert.ToInt32(code.Substring(i - 1, 1));
                if(i % 2 == 0)
                {
                    Sum += Digit * 3;
                }
                else
                {
                    Sum += Digit * 1;
                }
            }
            int checkSum = (10 - (Sum % 10)) % 10;
            code += checkSum.ToString();
            return code;
        }
    }
}
