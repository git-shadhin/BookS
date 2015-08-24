using System.Collections.Generic;
using Gender = BookS.Core.Maintenance.Common.Gender;

namespace BookS.Core.Models.MappedClasses
{
    public class AuthorMapping
    {
        public virtual int AuthorId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string DateOfBirth { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual IList<BookMapping> Books { get; set; }
    }
}
