using System;
using System.Collections.Generic;
using BookS.Core.Maintenance;
using BookS.Core.Models;

namespace BookS.Core.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorRepository : IAuthorRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public ResultInfo<Author> Add(Author pObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public ResultInfo<Author> Update(Author pObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public ResultInfo<Author> Remove(Author pObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthorId"></param>
        /// <returns></returns>
        public ResultInfo<Author> GetById(int pAuthorId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGenres"></param>
        /// <returns></returns>
        public ICollection<Author> GetByGenres(params Genre pGenres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDateOfBirth"></param>
        /// <returns></returns>
        public ICollection<Author> GetByDateOfBirth(DateTime pDateOfBirth)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSurname"></param>
        /// <returns></returns>
        public ICollection<Author> GetBySurname(string pSurname)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIsbn"></param>
        /// <returns></returns>
        public ICollection<Author> GetByBookIsbn(Isbn pIsbn)
        {
            throw new NotImplementedException();
        }
    }
}
