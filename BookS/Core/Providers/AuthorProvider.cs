using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
using BookS.Core.Models;

namespace BookS.Core.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorProvider : IDbServiceProvider<Author>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFilter"></param>
        /// <param name="pRequestedObject"></param>
        /// <returns></returns>
        public ResultInfo LoadFromDb(Predicate<Author> pFilter, out Author pRequestedObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFilter"></param>
        /// <param name="pAuthorsRequested"></param>
        /// <returns></returns>
        public ResultInfo LoadFromDb(Predicate<Author> pFilter, out List<Author> pAuthorsRequested)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthor"></param>
        /// <returns></returns>
        public ResultInfo SaveToDb(Author pAuthor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthor"></param>
        /// <returns></returns>
        public ResultInfo UpdateInDb(Author pAuthor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthor"></param>
        /// <returns></returns>
        public ResultInfo DeleteFromDb(Author pAuthor)
        {
            throw new NotImplementedException();
        }
    }
}
