using INCommon.DataExchange;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDatabase.DAO
{
    public class CompanyDAO : GenericDAO<Company>
    {
        private static CompanyDAO _instance;
        public static CompanyDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompanyDAO();
                }
                return _instance;
            }
        }

        public Company GetCompanyDataByNumber(string number, ISession session)
        {
            Company company = new Company();

            company = session.QueryOver<Company>().WhereRestrictionOn(p => p.Number).IsLike(number).SingleOrDefault();

            return company;
        }
    }
}
