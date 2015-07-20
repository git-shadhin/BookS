using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
using BookS.Core.Providers;

namespace BookS.Core.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Book : IValidator<Book>
    {
        #region fields

        private IDbServiceProvider<Book> mBookProvider;
        public IDbServiceProvider<Book> BookProvider
        {
            get { return mBookProvider ?? (mBookProvider = new BookProvider()); }
        }

        public int BookId { get; private set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        private Isbn mIsbn;
        public Isbn Isbn
        {
            get { return mIsbn; }
            set
            {
                if (mIsbn == null) { mIsbn = new Isbn(); }

                ValidationResult lResult = mIsbn.ValidateAndAssign(value);

                // TODO
            }
        }

        private List<Author> mAuthors;
        public List<Author> Authors
        {
            get { return mAuthors; }
            set
            {
                if (mAuthors == null) { mAuthors = new List<Author>(); }

                foreach (Author a in value)
                {
                    ValidationResult lResult = a.Validate();
                    
                    // TODO
                    mAuthors.Add(a);
                }
            }
        }

        private List<Translator> mTranslators;
        public List<Translator> Translators
        {
            get { return mTranslators; }
            set { mTranslators = value; }
        }
        
        private BookCover mCover;
        public BookCover Cover
        {
            get { return mCover; }
            set { mCover = value; }
        }

        private BookDetails mDetails;
        public BookDetails Details
        {
            get { return mDetails; }
            set { mDetails = value; }
        }

        private List<Genre> mGenres;
        public List<Genre> Genres
        {
            get { return mGenres; }
            set { mGenres = value; }

        }
        
        #endregion

        #region methods

        /// <summary>
        /// 
        /// </summary>
        public Book()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBookProvider"></param>
        public Book(IDbServiceProvider<Book> pBookProvider)
        {
            mBookProvider = pBookProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ResultInfo CreateBook()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Book> BookLoader(Predicate<Book> pFilter)
        {
            List<Book> lBooks;
            ResultInfo lResult = mBookProvider.LoadFromDb(pFilter, out lBooks);

            // Todo return value depends on result info
            return lBooks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBookId"></param>
        /// <returns></returns>
        public Book BookLoader(int pBookId)
        {
            Book lBook;
            ResultInfo lResult = mBookProvider.LoadFromDb(x => x.BookId == pBookId, out lBook);

            // TODO
            return lBook;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }

        #endregion

        #region validator interface implementations

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBook"></param>
        /// <returns></returns>
        public ValidationResult ValidateAndAssign(Book pBook)
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
        public bool? Compare(Book pObject1, Book pObject2)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
