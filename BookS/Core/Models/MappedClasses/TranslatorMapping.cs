using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
using NHibernate.Type;
using Gender = BookS.Core.Maintenance.Common.Gender;

namespace BookS.Core.Models.MappedClasses
{
    public class TranslatorMapping
    {
        protected virtual int TranslatorId { get; set; }
        protected virtual string Name { get; set; }
        protected virtual string Surname { get; set; }
        protected virtual Gender Gender { get; set; }
        protected virtual IList<Book> Books { get; set; }  
    }
}
