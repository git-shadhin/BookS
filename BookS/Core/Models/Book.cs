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
    /// This class represents Book object
    /// </summary>
    public class Book : IValidator<Book>
    {
        #region Private Fields

        private IAuthorRepository mAuthorRepository;
        private IBookRepository mBookRepository;
        private IBookCoverRepository mBookCover;
        private IBookDetailsRepository mBookDetailsRepository;
        private ITranslatorRepository mTranslatorRepository;
        private IGenreRepository mGenreRepository;

        protected int mBookId;
        protected string mTitle;
        protected string mOriginalTitle;
        protected BookCover mCover;
        protected BookDetails mBookDetails;
        protected DateTime mCreationDate;
        protected Isbn mIsbn;
        protected IList<Author> mAuthors;
        protected IList<Translator> mTranslators;
        protected IList<Genre> mGenres;

        // borrows and lends
        protected int mBorrowId;
        protected int mLendId;

        // storage
        protected int mStorageId;

        #endregion

        #region Properties
        
        private IAuthorRepository AuthorRepository
        {
            get { return mAuthorRepository ?? (mAuthorRepository = new AuthorRepository()); }
        }
        
        private IBookRepository BookRepository
        {
            get { return mBookRepository ?? (mBookRepository = new BookRepository()); }
        }
        
        public int BookId
        {
            get { return mBookId; }
            protected set { mBookId = value; }
        }

        public string Title
        {
            get { return mTitle; }
            set { mTitle = value ?? string.Empty; }
        }

        public string OriginalTitle
        {
            get { return mOriginalTitle; }
            set { mOriginalTitle = value ?? string.Empty; }
        }
        
        public Isbn Isbn
        {
            get { return mIsbn; }
            set { AssignIsbn(value); }
        }

        public BookCover Cover
        {
            get { return mCover; }
            set { AssignBookCover(value); }
        }

        public BookDetails BookDetails
        {
            get { return mBookDetails; }
            set { AssignBookDetails(value); }
        }

        public IList<Author> Authors
        {
            get { return GetBookAuthors(); }
            set { mAuthors = value; }
        }

        public IList<Translator> Translators
        {
            get { return GetBookTranslators(); }
            set { mTranslators = value; }
        }
        
        public IList<Genre> Genres
        {
            get { return GetBookGenres(); }
            set { mGenres = value; }
        }

        public DateTime CreationDate
        {
            get { return mCreationDate; }
            protected set { mCreationDate = value; }
        }

        public int BorrowId
        {
            get { return mBorrowId; }
            set { mBorrowId = value; }
        }

        public int LendId
        {
            get { return mLendId; }
            set { mLendId = value; }
        }

        public int StorageId
        {
            get { return mStorageId; }
            set { mStorageId = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public Book()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBookRepository"></param>
        /// <param name="pAuthorRepository"></param>
        public Book(IBookRepository pBookRepository, IAuthorRepository pAuthorRepository)
        {
            mBookRepository = pBookRepository;
            mAuthorRepository = pAuthorRepository;
            CreationDate = DateTime.Now;
        }

        private IList<Author> GetBookAuthors()
        {
            // TODO
            return new List<Author>();
        }

        private IList<Translator> GetBookTranslators()
        {
            // TODO
            return new List<Translator>();
        }

        private IList<Genre> GetBookGenres()
        {
            // TODO
            return new List<Genre>();
        }

        private void AssignIsbn(Isbn pIsbn)
        {

        }

        protected void AssignIsbn(string pIsbn)
        {
            
        }

        private void AssignBookCover(BookCover pBookCover)
        {

        }

        protected void AssignBookCover(int pBookCoverId)
        {
            
        }

        private void AssignBookDetails(BookDetails pBookDetails)
        {

        }

        protected void AssignBookDetails(int pBookDetailsId)
        {
            
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
            AddAuthorForTheBook(pAuthor);
        }

        private static void ValidateAuthor(IValidator<Author> pAuthor)
        {
            ValidationResult lResult = pAuthor.Validate();

            if (lResult.Status != ValidationStatus.Success)
                throw new ValidationException(lResult.Message, lResult.Status);
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
        /// <param name="pTranslator"></param>
        public void AddTranslator(Translator pTranslator)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGenre"></param>
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

        private void AddAuthorForTheBook(Author pAuthor)
        {
            // check if author exists in database

            // add author reference for this book

        }

        private void AddTranslatorForTheBook(Translator pTranslator)
        {

        }

        private void AddGenreForTheBook(Genre pGenre)
        {

        }

        #endregion
    }
}
