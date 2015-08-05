using System;
using System.Collections.Generic;
using BookS.Core.Maintenance;
using BookS.Core.Models;

namespace BookS.Core.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public ResultInfo<Book> Add(Book pObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public ResultInfo<Book> Update(Book pObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public ResultInfo<Book> Remove(Book pObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBookId"></param>
        /// <returns></returns>
        public ResultInfo<Book> GetById(int pBookId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIsbn"></param>
        /// <returns></returns>
        public ResultInfo<Book> GetByIsbn(string pIsbn)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTitle"></param>
        /// <returns></returns>
        public ResultInfo<Book> GetByTitle(string pTitle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCover"></param>
        /// <returns></returns>
        public ResultInfo<Book> GetByCover(BookCover pCover)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthors"></param>
        /// <returns></returns>
        public ICollection<Book> GetByAuthors(params Author[] pAuthors)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTranslators"></param>
        /// <returns></returns>
        public ICollection<Book> GetByTranslators(params Translator[] pTranslators)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGenres"></param>
        /// <returns></returns>
        public ICollection<Book> GetByGenres(params Genre[] pGenres)
        {
            throw new NotImplementedException();
        }
    }
}
