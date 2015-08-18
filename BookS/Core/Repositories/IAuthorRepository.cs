using System;
using System.Collections.Generic;
using BookS.Core.Models;

namespace BookS.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetById(int pAuthorId);
        IList<Author> GetByGenres(params Genre[] pGenres);
        IList<Author> GetByDateOfBirth(DateTime pDateOfBirth);
        IList<Author> GetBySurname(string pSurname);
        IList<Author> GetByBookIsbn(Isbn pIsbn);
    }
}
