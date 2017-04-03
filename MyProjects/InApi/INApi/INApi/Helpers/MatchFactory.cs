using INApi.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.Helpers
{
    public class MatchFactory
    {
        public NumberBase MatchNumber(IList<IMatchNumber> numbersToCheck, string number)
        {
            foreach(var n in numbersToCheck)
            {
                if(n.IsMatch(number))
                {
                    return n.GetNewInstance();
                }
            }

            return null;
        }
    }
}
