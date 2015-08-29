using System;
using System.Collections.Generic;
using BookS.Core.Maintenance;
using BookS.Core.Models;

namespace BookS.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        ResultInfo<Author> GetById(int pAuthorId);
        ResultInfo<IEnumerable<Author>> GetByGenres(params Genre[] pGenres);
        ResultInfo<IEnumerable<Author>> GetByDateOfBirth(DateTime pDateOfBirth);
        ResultInfo<IEnumerable<Author>> GetBySurname(string pSurname);
        ResultInfo<IEnumerable<Author>> GetByFullName(string pFullname);
        ResultInfo<IEnumerable<Author>> GetByBookIsbn(Isbn pIsbn);
    }
}
