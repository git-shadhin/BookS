using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookS.Core.Models.MappedClasses
{
    public class GenreMapping : Genre
    {
        public virtual int GenreId { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Book> Books { get; set; } 
    }
}
