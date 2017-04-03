using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace INCommon.DataExchange
{
    [DataContract]
    public class Log
    {
        public virtual int Id { get; set; }
        public virtual DateTime LogDate { get; set; }
        public virtual string Status { get; set; }
        public virtual string ErrorMessage { get; set; }
        public virtual string HttpHeader { get; set; }
    }
}
