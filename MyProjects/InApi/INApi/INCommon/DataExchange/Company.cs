using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace INCommon.DataExchange
{
    [DataContract]
    public class Company
    {
        public virtual int Id { get; set; }
        public virtual string Number { get; set; }
        public virtual string Name { get; set; }
        public virtual string Street { get; set; }
        public virtual string StreetNumber { get; set; }
        public virtual string PostCode { get; set; }
        public virtual string City { get; set; }
    }
}
