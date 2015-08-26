using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
using BookS.Core.Models;
using BookS.Core.Models.MappedClasses;
using BookS.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using WebResponseDataPicker.Properties;

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
        public void NHibernateInsertAndQueryAndRemoveTest()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var author = new AuthorMapping
                {
                    Name = "Admin",
                    Surname = "mindA",
                    DateOfBirth = "01.04.1993",
                    Gender = Gender.Male.ToString()
                };

                session.Save(author);

                var authorFromDb = session.Query<AuthorMapping>().FirstOrDefault(x => x.Name == "Admin");

                Assert.IsTrue(authorFromDb != null);
                Assert.AreEqual(authorFromDb.Name, "Admin");
                Assert.AreEqual(authorFromDb.Surname, "mindA");
                Assert.AreEqual(authorFromDb.DateOfBirth, "01.04.1993");
                Assert.AreEqual(authorFromDb.Gender, Gender.Male.ToString());
                
                session.Delete(authorFromDb);

                var authorFromDb2 = session.Query<AuthorMapping>().FirstOrDefault(x => x.AuthorId == authorFromDb.AuthorId);

                Assert.IsTrue(authorFromDb2 == null);

                transaction.Commit();
            }
        }
    }
}
