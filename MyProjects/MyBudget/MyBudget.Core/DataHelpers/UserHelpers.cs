using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBudget.Core.DataTransferObject;

namespace MyBudget.Core.DataHelpers
{
    public class UserHelper
    {
        private static UserHelper _instance;
        private User user;

        public static UserHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserHelper();
                }
                return _instance;
            }

        }

        public User GetUser
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }


    }
}
