using INApi.DataContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.Executor
{
    public interface IExecutor<T>
    {
        IDataContent<T> GetData();
    }
}
