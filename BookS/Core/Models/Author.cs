using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookS.Core.Maintenance;
using BookS.Core.Models.MappedClasses;
using BookS.Core.Repositories;

namespace BookS.Core.Models
{
    /// <summary>
    /// This class defines an object which represents writer.
    /// </summary>
    public class Author : IValidator<Author>
    {
        #region Private Fields

        private IBookRepository mBookRepository;
        private IAuthorRepository mAuthorRepository;

        protected int mAuthorId;
        protected string mName;
        protected string mSurname;
        protected DateTime mDateOfBirth;
        protected Gender mGender;
        protected IList<Book> mBooks; 

        #endregion

        #region Properties

        private IBookRepository BookRepository
        {
            get { return mBookRepository ?? (mBookRepository = new BookRepository()); }
        }

        private IAuthorRepository AuthorRepository
        {
            get { return mAuthorRepository ?? (mAuthorRepository = new AuthorRepository()); }
        }

        public int AuthorId
        {
            get { return mAuthorId; }
            set { mAuthorId = value; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value ?? string.Empty; }
        }

        public string Surname
        {
            get { return mSurname; }
            set { mSurname = value ?? string.Empty; }
        }

        public DateTime DateOfBirth
        {
            get { return mDateOfBirth; }
            set { mDateOfBirth = value; }
        }

        public Gender Gender
        {
            get { return mGender; }
            set { mGender = value; }
        }

        public IList<Book> Books
        {
            get { return GetAuthorBooks(); }
            set { mBooks = value ?? new List<Book>(); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// This is a default constructor of Author class object.
        /// </summary>
        public Author()
        {
        }

        /// <summary>
        /// This is Author class constructor which allows to set Repository for the AuthorBooks.
        /// </summary>
        /// <param name="pAuthorRepository">Repository which allows to get author data</param>
        /// <param name="pBookRepository">Repository which allows to get authors' books</param>
        public Author(IAuthorRepository pAuthorRepository, IBookRepository pBookRepository)
        {
            mAuthorRepository = pAuthorRepository;
            mBookRepository = pBookRepository;
        }

        private IList<Book> GetAuthorBooks()
        {
            mBooks = BookRepository.GetByAuthors(this);
            UpdateDatabaseWithAuthorBooks();

            return mBooks;
        }

        private void UpdateDatabaseWithAuthorBooks()
        {
            ResultInfo<Author> result = AuthorRepository.Update(this);

            if (result.Status != ResultStatus.Success)
            {
                throw new ResultInfoException<Author>(result);
            }
        }

        #endregion

        #region Validator Interface Implementations

        private ValidationResult mValidationResult;
        public ValidationResult ValidationResult
        {
            get { return mValidationResult ?? (mValidationResult = new ValidationResult()); }
        }

        /// <summary>
        /// This method checks if data stored in Author object is correct.
        /// </summary>
        /// <returns>
        /// ValidationResult class which stores information about the result of the validation process.
        /// </returns>
        public ValidationResult Validate()
        {
            try
            {
                ValidateName(Name);
                ValidateSurname(Surname);
                ValidateDateOfBirth(DateOfBirth);

                ValidationResult.Status = ValidationStatus.Success;
                ValidationResult.Message = "Author Properties are correct";
            }
            catch (ValidationException e)
            {
                ValidationResult.Status = e.Status;
                ValidationResult.Message = e.ValidationMessage;
                ValidationResult.ExceptionMessage = e.Message;
            }

            return ValidationResult;
        }

        private static void ValidateName(string pAuthorName)
        {
            if (pAuthorName == null)
                throw new ValidationException("Author Name property is null", ValidationStatus.NullReference);

            if (pAuthorName == String.Empty)
                throw new ValidationException("Author Name property cannot be empty", ValidationStatus.EmptyField);
        }

        private static void ValidateSurname(string pAuthorSurname)
        {
            if (pAuthorSurname == null)
                throw new ValidationException("Author Surname property is null", ValidationStatus.NullReference);

            if (pAuthorSurname == String.Empty)
                throw new ValidationException("Author Surname property cannot be empty", ValidationStatus.EmptyField);
        }

        private static void ValidateDateOfBirth(DateTime pAuthorDateOfBirth)
        {
            if (pAuthorDateOfBirth == null)
                throw new ValidationException("Author DateOfBirth property is null", ValidationStatus.NullReference);

            if (pAuthorDateOfBirth == default(DateTime))
                throw new ValidationException("Author DateOfBirth property cannot be default", ValidationStatus.EmptyField);
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Summarises the author object data in well formated manner.
        /// </summary>
        /// <returns>
        /// String containing Author object data description.
        /// </returns>
        public override string ToString()
        {
            StringBuilder description = new StringBuilder("Author object description");

            description.AppendLine("[ID]: " + AuthorId).AppendLine("[Name]: " + Name)
                .AppendLine("[Surname]: " + Surname).AppendLine("[DateOfBirth]: " + DateOfBirth.ToString("d"))
                .AppendLine("[Gender]: " + Gender);

            description.AppendLine("Books written: " + Books.Count);

            foreach (var book in Books)
            {
                description.AppendLine("[Book]:").AppendLine(book.ToString());
            }

            return description.ToString();
        }

        /// <summary>
        /// This method compares two Author objects by their properties values.
        /// </summary>
        /// <param name="pAuthor1">First Author object to compare</param>
        /// <param name="pAuthor2">Second Author object to compare</param>
        /// <returns>
        /// True if Author objects are the same and false otherwise.
        /// Returns null if one of the given objects are null.
        /// </returns>
        public static bool? Compare(Author pAuthor1, Author pAuthor2)
        {
            if (pAuthor1 == null || pAuthor2 == null)
            {
                return null;
            }

            return CompareProperties(pAuthor1, pAuthor2);
        }

        private static bool CompareProperties(Author pAuthor1, Author pAuthor2)
        {
            var author1Properties = pAuthor1.GetType().GetProperties().ToList();
            var author2Properties = pAuthor2.GetType().GetProperties().ToList();

            for (int i = 0; i < author1Properties.Count; i++)
            {
                if (author1Properties[i].Attributes != author2Properties[i].Attributes)
                    return false;
            }

            return true;
        }

        #endregion
    }
}
