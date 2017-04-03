using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INApi.Executor;
using INApi.Helpers;
using INCommon.DataExchange;
using INApi.DataContent;

namespace INApi.Proxy
{
    public class NumberProxy
    {
        private IExecutor<Company> executor;

        public IDataContent<Company> GetCompanyData(List<IMatchNumber> numbersTypeToCheck, string number, string headers)
        {
            IDataContent<Company> company = new CompanyContent();

            executor = new CompanyExecutor(numbersTypeToCheck, number, headers);

            company = executor.GetData();
            
            return company;
        }
    }
}
