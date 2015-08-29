using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookS.Core.Models.MappedClasses
{
    internal class GenreMapping : Genre
    {
        public virtual int GenreId { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<BookMapping> Books { get; set; } 
    }
}
