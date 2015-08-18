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
        private IAuthorRepository AuthorRepository
        {
            get { return mAuthorRepository ?? (mAuthorRepository = new AuthorRepository()); }
        }

        private IBookRepository mBookRepository;
        private IBookRepository BookRepository
        {
            get { return mBookRepository ?? (mBookRepository = new BookRepository()); }
        }

        public IBookCoverRepository mBookCover;
        public IBookDetailsRepository mBookDetailsRepository;
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
            set { AssignIsbn(value); }
        }

        public new IList<Author> Authors
        {
            get { return GetBookAuthors(); }
        }

        public new IList<Translator> Translators
        {
            get { return GetBookTranslators(); }
        }

        public new IList<Genre> Genres
        {
            get { return GetBookGenres(); }
        }

        private BookCover mCover;
        public BookCover Cover
        {
            get { return mCover; }
            set { AssignBookCover(value); }
        }

        private BookDetails mDetails;
        public BookDetails Details
        {
            get { return mDetails; }
            set { AssignBookDetails(value); }
        }


        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public Book() :
            this(new BookRepository(), new AuthorRepository())
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IList<Author> GetBookAuthors()
        {
            // TODO
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IList<Translator> GetBookTranslators()
        {
            // TODO
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IList<Genre> GetBookGenres()
        {
            // TODO
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIsbn"></param>
        private void AssignIsbn(Isbn pIsbn)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBookCover"></param>
        private void AssignBookCover(BookCover pBookCover)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBookDetails"></param>
        private void AssignBookDetails(BookDetails pBookDetails)
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
            AddAuthorForBook(pAuthor);
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
        private void AddAuthorForBook(Author pAuthor)
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
