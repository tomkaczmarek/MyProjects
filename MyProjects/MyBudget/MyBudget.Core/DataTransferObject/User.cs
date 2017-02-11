using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MyBudget.Core.DataTransferObject
{
    [DataContract]
    public class User
    {
        public virtual int Id{get; set;}
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual string Name { get; set; }
        public virtual string FullName { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
