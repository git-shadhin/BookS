using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
using NHibernate.Type;

namespace BookS.Core.Models.MappedClasses
{
    public class TranslatorMapping : Translator
    {
        public virtual int TranslatorId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual IList<Book> Books { get; set; }  
    }
}
