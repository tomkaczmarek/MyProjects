using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INApi.Util;

namespace INApi.Helpers
{
    public class MatchRegonNumber : IMatchNumber
    {
        public NumberBase GetNewInstance()
        {
            return new RegonNumber();
        }

        public bool IsMatch(string number)
        {          
            char[] n = number.ToCharArray();

            return (n.Length == 9 || n.Length == 14);
        }
    }
}
