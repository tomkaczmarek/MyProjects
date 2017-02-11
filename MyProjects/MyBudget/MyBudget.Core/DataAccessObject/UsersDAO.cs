using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using MyBudget.Core.DataTransferObject;
using MyBudget.Core.DBAccess;


namespace MyBudget.Core.DataAccessObject
{
    public partial class UserDAO : GenericActionDAO<User>
    {

        #region Singleton

        private static UserDAO _instance;
        public static UserDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserDAO();
                }
                return _instance;
            }
        }
        #endregion

        public bool IsUserExist(string login, ISession session)
        {
            var result = session.QueryOver<User>().WhereRestrictionOn(l => l.Login).IsLike(login).List();
            return result.Count > 0 ? true : false;
        }

        public bool IsUserActive(string login, ISession session)
        {
            bool result = session.QueryOver<User>().WhereRestrictionOn(l => l.Login).IsLike(login).Select(l => l.IsActive).SingleOrDefault<bool>();
            return result;
        }

        public User GetUserByLogin(string login, ISession session)
        {
            User result = session.QueryOver<User>().WhereRestrictionOn(l => l.Login).IsLike(login).SingleOrDefault();
            return result;
        }
        

    }
}
