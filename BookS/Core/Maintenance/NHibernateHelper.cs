using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace BookS.Core.Maintenance
{
    public class NHibernateHelper
    {
        private static ISessionFactory mSessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (mSessionFactory == null)
                {
                    Configuration cfg = new Configuration();
                    cfg.Configure();
                    mSessionFactory = cfg.BuildSessionFactory();

                    var schemaUpdate = new SchemaUpdate(cfg);
                    schemaUpdate.Execute(Console.WriteLine, true);
                }
                return mSessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
