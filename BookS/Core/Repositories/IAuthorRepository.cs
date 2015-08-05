using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
using BookS.Core.Models;

namespace BookS.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        ResultInfo<Author> GetById(int pAuthorId);
        ICollection<Author> GetByGenres(params Genre pGenres);
        ICollection<Author> GetByDateOfBirth(DateTime pDateOfBirth);
        ICollection<Author> GetBySurname(string pSurname);
        ICollection<Author> GetByBookIsbn(Isbn pIsbn);
    }
}
