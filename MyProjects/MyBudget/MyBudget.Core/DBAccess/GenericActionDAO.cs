using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace MyBudget.Core.DBAccess
{
    public abstract class GenericActionDAO<Type> where Type : class
    {
        public void Save(object o, ISession sesion)
        {
            sesion.Save(o);
        }

        public void Update(object o, ISession session)
        {
            session.Update(o);
        }

        public void Update(object o, int id, ISession session)
        {
            session.Update(o, id);
        }

        public int SaveAndGetId(object o , ISession session)
        {
            return (session.Save(o) as int?).GetValueOrDefault();
        }

        public Type Get(int id, ISession session)
        {
            return session.Get<Type>(id);
        }

    }
}
