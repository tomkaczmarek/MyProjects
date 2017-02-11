using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using MyBudget.Core.DBAccess;

namespace MyBudget.Core.NHibernate
{
    public class NHibernateManager 
    {
        private static ISession session;
        private static ISessionFactory sessionFactory;
        private static Configuration configuration;
        private static ITransaction transaction;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if(sessionFactory==null)
                {
                    configuration = new Configuration();
                    configuration.Configure();
                    SchemaManager.BuildSchema(configuration);
                    sessionFactory = configuration.BuildSessionFactory();
                }
                return sessionFactory;
            }
        }

        private static ISession Session
        {
            get
            {
                if (session == null)
                    BeginSessionTransaction();
                return session;
            }
            set
            {
                session = value;
            }
        }
        public static ISession BeginSessionTransaction()
        {
            Session = SessionFactory.OpenSession();
            return Session;
        }

        public static void CommitTransactionAndClose()
        {
            transaction = Session.BeginTransaction();
            transaction.Commit();
            CloseSessionTransaction();

        }
        public static void CloseSessionTransaction()
        {
            Session.Close();
        }
        private static void CloseSession(ISession session)
        {
            session.Clear();
        }

        public static void RollBackTransaction()
        {
            transaction.Rollback();
        }
    }
}
