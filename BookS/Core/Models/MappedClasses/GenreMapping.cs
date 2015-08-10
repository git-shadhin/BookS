using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookS.Core.Models.MappedClasses
{
    public class GenreMapping
    {
        protected virtual int GenreId { get; set; }
        protected virtual string Name { get; set; }
        protected virtual IList<Book> Books { get; set; } 
    }
}
