
using System;
using System.Collections.Generic;
using BookS.Core.Maintenance;
using BookS.Core.Models;

namespace BookS.Core.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class BookProvider : IDbServiceProvider<Book>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFilter"></param>
        /// <param name="pRequestedObject"></param>
        /// <returns></returns>
        public ResultInfo LoadFromDb(Predicate<Book> pFilter, out Book pRequestedObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFilter"></param>
        /// <param name="pBooksRequested"></param>
        /// <returns></returns>
        public ResultInfo LoadFromDb(Predicate<Book> pFilter, out List<Book> pBooksRequested)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBook"></param>
        /// <returns></returns>
        public ResultInfo SaveToDb(Book pBook)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBook"></param>
        /// <returns></returns>
        public ResultInfo UpdateInDb(Book pBook)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBook"></param>
        /// <returns></returns>
        public ResultInfo DeleteFromDb(Book pBook)
        {
            throw new NotImplementedException();
        }
    }
}
