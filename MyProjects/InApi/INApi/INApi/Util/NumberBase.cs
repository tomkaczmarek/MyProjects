using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.Util
{
    public abstract class NumberBase
    {
        public abstract bool IsValid(string number);

        public virtual string FormatNumber(string number)
        {
            char[] n = number.ToCharArray().Where(p => Char.IsDigit(p)).ToArray();
            return new string(n);
        }

        public virtual string ErrorMessage()
        {
            return "Podany numer jest niepoprawny";
        }

        public virtual bool CheckSum(char[] number, int[] weight)
        {
            int sum = 0;
            for (int i = 0; i < weight.Length; i++)
            {
                int z = (int)Char.GetNumericValue(number[i]) * weight[i];
                sum += z;
            }
            return sum % 11 == (int)Char.GetNumericValue(number.Last());
        }
    }
}
