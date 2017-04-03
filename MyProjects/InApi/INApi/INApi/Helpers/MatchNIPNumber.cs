using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INApi.Util;

namespace INApi.Helpers
{
    public class MatchNIPNumber : IMatchNumber
    {
        public NumberBase GetNewInstance()
        {
            return new NIPNumber();
        }

        public bool IsMatch(string number)
        {
            char[] n = number.ToCharArray().Where(p => Char.IsDigit(p)).ToArray();
            return n.Length == 10;
        }
    }
}
