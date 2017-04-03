using INApi.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.Helpers
{
    public interface IMatchNumber
    {
        NumberBase GetNewInstance();
        bool IsMatch(string number);
    }
}
