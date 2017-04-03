using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.Util
{
    public class NIPNumber : NumberBase
    {
        public override bool IsValid(string number)
        {
            number = FormatNumber(number);
            int[] weight = new int[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            return base.CheckSum(number.ToArray(), weight);
        }
    }
}
