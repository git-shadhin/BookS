using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Models.MappedClasses;
using NHibernate;
using NHibernate.Cfg;

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

                    AddAssemblies(cfg);

                    mSessionFactory = cfg.BuildSessionFactory();
                }
                return mSessionFactory;
            }
        }

        private static void AddAssemblies(Configuration pCfg)
        {
            pCfg.AddAssembly(typeof(AuthorMapping).Assembly);
            pCfg.AddAssembly(typeof(BookMapping).Assembly);
            pCfg.AddAssembly(typeof(GenreMapping).Assembly);
            pCfg.AddAssembly(typeof(TranslatorMapping).Assembly);
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
