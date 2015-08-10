using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
using BookS.Core.Models.MappedClasses;
using BookS.Core.Repositories;
using NHibernate;

namespace BookS.Core.Models
{
    /// <summary>
    /// 
    /// </summary>
    sealed public class Book : BookMapping, IValidator<Book>
    {
        #region Fields

        private IAuthorRepository mAuthorRepository;
        public IAuthorRepository AuthorRepository
        {
            get { return mAuthorRepository ?? (mAuthorRepository = new AuthorRepository()); }
        }

        public IBookCoverRepository mBookCover;
        public IBookDetailsRepository mBookRepository;
        public ITranslatorRepository mTranslatorRepository;
        public IGenreRepository mGenreRepository;

        public new int BookId
        {
            get { return base.BookId; }
        }

        public new string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
        }

        public new string OriginalTitle
        {
            get { return base.OriginalTitle; }
            set { base.OriginalTitle = value; }
        }

        public new int BookDetailId
        {
            get { return base.BookDetailId; }
            set { base.BookDetailId = value; }
        }

        public new int BorrowId
        {
            get { return base.BorrowId; }
            set { base.BorrowId = value; }
        }

        public new int LendId
        {
            get { return base.LendId; }
            set { base.LendId = value; }
        }

        public new DateTime CreationDate
        {
            get { return base.CreationDate; }
            private set { base.CreationDate = value; }
        }

        private Isbn mIsbn;
        public new Isbn Isbn
        {
            get { return mIsbn; }
            set
            {
                mIsbn = value;
                ValidationResult lResult = mIsbn.Validate();

                
                // TODO
            }
        }
        
        private IList<Author> mAuthors;
        public new IList<Author> Authors
        {
            get { return mAuthors ?? (mAuthors = new List<Author>()); }
        }

        private IList<Translator> mTranslators;
        public IList<Translator> Translators
        {
            get { return mTranslators ?? (mTranslators = new List<Translator>()); }
        }
        
        private IList<Genre> mGenres;
        public new IList<Genre> Genres
        {
            get { return mGenres ?? (mGenres = new List<Genre>()); }
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

        
        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public Book() :
            this(new AuthorRepository())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthorRepository"></param>
        public Book(IAuthorRepository pAuthorRepository)
        {
            mAuthorRepository = pAuthorRepository;

            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthor"></param>
        /// <exception cref="ValidationException"/>
        /// <exception cref="ResultException"/>
        public void AddAuthor(Author pAuthor)
        {
            ValidateAuthor(pAuthor);
            FetchAuthor(pAuthor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthor"></param>
        /// <exception cref="ValidationException"/>
        private static void ValidateAuthor(IValidator<Author> pAuthor)
        {
            ValidationResult lResult = pAuthor.Validate();

            if (lResult.Status != ValidationStatus.Success)
                throw new ValidationException(lResult.ExceptionMessage, lResult.Status, lResult.Message);           
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject1"></param>
        /// <param name="pObject2"></param>
        /// <returns></returns>
        public static bool? Compare(Book pObject1, Book pObject2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthor"></param>
        /// <exception cref="ResultException"/>
        private void FetchAuthor(Author pAuthor)
        {
            ResultInfo<Author> lResultInfo = AddAuthorForBook(pAuthor);
            if (lResultInfo.Status != ResultStatus.Success)
                throw new ResultException();

            mAuthors.Add(pAuthor);                        
        }

        public void AddTranslator(Translator pTranslator)
        {
            
        }

        public void AddGenre(Genre pGenre)
        {

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

        #region Validator Interface Implementations

        public ValidationResult ValidationResult { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValidationResult Validate()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Fields Repositories Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthor"></param>
        /// <returns></returns>
        private ResultInfo<Author> AddAuthorForBook(Author pAuthor)
        {
            // check if author exists in database

            // add author reference for this book

        }

        private ResultInfo<Translator> AddTranslatorForTheBook(Translator pTranslator)
        {
            
        }

        private ResultInfo<Genre> AddGenreForTheBook(Genre pGenre)
        {
            
        }

        #endregion
    }
}
