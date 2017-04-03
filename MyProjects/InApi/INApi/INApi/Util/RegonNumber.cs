using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.Util
{
    public class RegonNumber : NumberBase
    {

        public override bool IsValid(string number)
        {
            return CheckSum(number.ToArray());
        }

        private bool CheckSum(char[] number)
        {
            int[] weight;
            if (number.Length == 9)
            {
                weight = new int[] { 8, 9, 2, 3, 4, 5, 6, 7 };
            }
            else
            {
                weight = new int[] { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
            }
            return base.CheckSum(number, weight);             
        }
    }
}
