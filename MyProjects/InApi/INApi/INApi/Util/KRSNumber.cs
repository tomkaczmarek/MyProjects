using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.Util
{
    public class KRSNumber : NumberBase
    {
        public override bool IsValid(string number)
        {
            return true;
        }
    }
}
