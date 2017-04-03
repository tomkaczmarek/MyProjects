
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDatabase.DAO
{
    public abstract class GenericDAO<T> where T : class
    {
        public void Save(object o, ISession session)
        {
            session.Save(o);
        }

        public T Get(int id, ISession session)
        {
            return session.Get<T>(id);
        }
    }
}
