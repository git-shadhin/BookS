using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Models.MappedClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Tests.Other
{
    [TestClass]
    public class TestGenerateSchema
    {
        [TestMethod]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof (AuthorMapping).Assembly);
            cfg.AddAssembly(typeof (BookMapping).Assembly);
            cfg.AddAssembly(typeof (GenreMapping).Assembly);
            cfg.AddAssembly(typeof (TranslatorMapping).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }
    }
}
