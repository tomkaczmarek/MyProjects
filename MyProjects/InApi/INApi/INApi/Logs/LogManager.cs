using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INApi.DataContent;
using INCommon.DataExchange;
using INDatabase.NHibernate;
using INDatabase.DAO;
using NHibernate;

namespace INApi.Logs
{
    public class LogManager
    {
        public void LogData<T>(IDataContent<T> data)
        {
            Log log = new Log();
            log.ErrorMessage = data.Message;
            log.Status = data.Status;
            log.LogDate = DateTime.Now;
            log.HttpHeader = data.Headers;
            
            try
            {
                ISession session = NHibernateManager.BeginSessionTransaction();
                LogDAO.Instance.Save(log, session);
                NHibernateManager.CommitTransactionAndClose();
            }
            catch(Exception e)
            {
                NHibernateManager.RollBackTransaction();
                throw new Exception(e.Message);
            }
        }
    }
}
