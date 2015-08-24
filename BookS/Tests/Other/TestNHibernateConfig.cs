using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
using BookS.Core.Models;
using BookS.Core.Models.MappedClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

namespace Tests.Other
{
    [TestClass]
    public class TestNHibernateConfig
    {
        [TestMethod]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();

            cfg.BuildSessionFactory();

            var schemaUpdate = new SchemaUpdate(cfg);
            schemaUpdate.Execute(Console.WriteLine, true);
        }

        [TestMethod]
        public void NHiberanteDbAccessPatternCheck()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {

                transaction.Commit();
            }
        }

        [TestMethod]
        public void NHibernateInsertTest()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                

                transaction.Commit();
            }
        }
    }
}
