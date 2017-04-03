using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.DataContent
{
    public interface IDataContent<T>
    {
        T Data { get; set; }
        string Message { get; set; }
        string Status { get; set; }
        string Headers { get; set; }
    }
}
