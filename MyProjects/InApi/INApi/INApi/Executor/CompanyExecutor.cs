using INApi.DataContent;
using INApi.Helpers;
using INApi.Logs;
using INApi.Util;
using INCommon.DataExchange;
using INDatabase.DAO;
using INDatabase.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.Executor
{
    public class CompanyExecutor : IExecutor<Company>
    {
        public string Number { get; set; }
        public List<IMatchNumber> NumbersToCheck { get; }
        public string Headers { get; set; }

        public CompanyExecutor(List<IMatchNumber> numbersToCheck, string number, string headers)
        {
            Number = number;
            NumbersToCheck = numbersToCheck;
            Headers = headers;
        }

        public IDataContent<Company> GetData()
        {
            IDataContent<Company> dataContent = new CompanyContent();
            dataContent.Headers = Headers;

            MatchFactory factory = new MatchFactory();

            NumberBase concreteNumberType = factory.MatchNumber(NumbersToCheck, Number);

            if(concreteNumberType != null && concreteNumberType.IsValid(Number))
            {
                try
                {
                    Number = concreteNumberType.FormatNumber(Number);
                    ISession session = NHibernateManager.BeginSessionTransaction();
                    dataContent.Data = CompanyDAO.Instance.GetCompanyDataByNumber(Number, session);
                    NHibernateManager.CloseSessionTransaction();
                    dataContent.Status = StatusEnum.Valid.ToString();
                    if (dataContent.Data == null)
                    {
                        dataContent.Message = "Brak danych";
                        dataContent.Status = StatusEnum.Error.ToString();
                    }
                    
                }
                catch(Exception e)
                {
                    NHibernateManager.CloseSessionTransaction();
                    throw new Exception(e.Message);                
                }             
            }
            else
            {
                dataContent.Message = "Podany numer jest niepoprawny";
                dataContent.Status = StatusEnum.Error.ToString();
            }
            LogManager log = new LogManager();
            log.LogData(dataContent);

            return dataContent;

        }
    }
}
