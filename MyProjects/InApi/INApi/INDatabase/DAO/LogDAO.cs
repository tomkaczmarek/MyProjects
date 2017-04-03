using INCommon.DataExchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDatabase.DAO
{
    public class LogDAO : GenericDAO<Log>
    {
        private static LogDAO _instance;
        public static LogDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LogDAO();
                }
                return _instance;
            }
        }
    }
}
