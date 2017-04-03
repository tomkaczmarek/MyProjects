using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INApi.Util;

namespace INApi.Helpers
{
    public class MatchKRSNumber : IMatchNumber
    {
        public NumberBase GetNewInstance()
        {
            return new KRSNumber();
        }

        public bool IsMatch(string number)
        {
            return true;
        }
    }
}
