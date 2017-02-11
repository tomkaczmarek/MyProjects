using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBudget.Common.DataExchange.Generic;

namespace MyBudget.Common.DataExchange
{
    public class UserVector : AbstactVector
    {
        public UserVector() { }

        public UserVector(string login, string password, string fullName)
        {
            Login = login;
            Password = password;
            FullName = fullName;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
    }
}
