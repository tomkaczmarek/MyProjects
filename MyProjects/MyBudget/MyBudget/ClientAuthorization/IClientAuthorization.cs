﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.ClientAuthorization
{
    interface IUserAuthorization
    {
        bool PasswordCheck(string password);
    }
}
