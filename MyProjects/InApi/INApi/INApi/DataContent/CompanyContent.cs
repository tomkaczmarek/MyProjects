using INCommon.DataExchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.DataContent
{
    public class CompanyContent : IDataContent<Company>
    {
        public Company Data { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Headers { get; set; }
    }
}
