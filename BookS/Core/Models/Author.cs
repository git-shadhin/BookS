using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
using BookS.Core.Providers;

namespace BookS.Core.Models
{
    public class Author: IValidator<Author>
    {
        private IDbServiceProvider<Author> mAuthorProvider;
        public IDbServiceProvider<Author> AuthorProvider
        {
            get { return mAuthorProvider ?? (mAuthorProvider = new AuthorProvider()); }
        }

        public int AuthorId { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Author()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthorProvider"></param>
        public Author(IDbServiceProvider<Author> pAuthorProvider)
        {
            mAuthorProvider = pAuthorProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInObject"></param>
        /// <returns></returns>
        public ValidationResult ValidateAndAssign(Author pInObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValidationResult Validate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject1"></param>
        /// <param name="pObject2"></param>
        /// <returns></returns>
        public bool? Compare(Author pObject1, Author pObject2)
        {
            throw new NotImplementedException();
        }
    }
}
