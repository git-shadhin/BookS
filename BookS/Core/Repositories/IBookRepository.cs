using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
using BookS.Core.Models;

namespace BookS.Core.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        ResultInfo<Book> GetById(int pBookId);
        ResultInfo<Book> GetByIsbn(string pIsbn);
        ResultInfo<Book> GetByTitle(string pTitle);
        ResultInfo<Book> GetByCover(BookCover pCover);
        IList<Book> GetByAuthors(params Author[] pAuthors);
        IList<Book> GetByTranslators(params Translator[] pTranslators);
        IList<Book> GetByGenres(params Genre[] pGenres);
    }
}
