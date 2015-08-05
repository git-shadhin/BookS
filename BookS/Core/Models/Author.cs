using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookS.Core.Maintenance;
using BookS.Core.Models.MappedClasses;
using Gender = BookS.Core.Maintenance.Common.Gender;

namespace BookS.Core.Models
{
    /// <summary>
    /// This class defines an object which represents some writer.
    /// </summary>
    sealed public class Author : AuthorMapping, IValidator<Author>
    {
        #region Fields
        public new int AuthorId { get { return base.AuthorId; } }

        public new IList<Book> Books
        {
            get { return base.Books; }
            set { base.Books = value ?? new List<Book>(); }
        }

        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value ?? string.Empty; }
        }

        public new string Surname
        {
            get { return base.Surname; }
            set { base.Surname = value ?? string.Empty; }
        }

        public new DateTime DateOfBirth
        {
            get { return DateTime.Parse(base.DateOfBirth); }
            set { base.DateOfBirth = value.ToString("d"); }
        }

        public new Gender Gender
        {
            get { return base.Gender; }
            set { base.Gender = value; }
        }

        #endregion

        #region Constructor

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthorName"></param>
        private static void ValidateName(string pAuthorName)
        {
            if (pAuthorName == null)
                throw new ValidationException("Author Name property is null", ValidationStatus.NullReference);

            if (pAuthorName == String.Empty)
                throw new ValidationException("Author Name property cannot be empty", ValidationStatus.EmptyField);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthorSurname"></param>
        private static void ValidateSurname(string pAuthorSurname)
        {
            if (pAuthorSurname == null)
                throw new ValidationException("Author Surname property is null", ValidationStatus.NullReference);

            if (pAuthorSurname == String.Empty)
                throw new ValidationException("Author Surname property cannot be empty", ValidationStatus.EmptyField);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAuthorDateOfBirth"></param>
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

        /// <summary>
        /// This method compares every property of two Author objects with each other.
        /// </summary>
        /// <param name="pAuthor1">First Author object to compare</param>
        /// <param name="pAuthor2">Second Author object to compare</param>
        /// <returns>
        /// True if Author objects are the same and false otherwise.
        /// </returns>
        private static bool CompareProperties(Author pAuthor1, Author pAuthor2)
        {
            var lAuthor1Properties = pAuthor1.GetType().GetProperties().ToList();
            var lAuthor2Properties = pAuthor2.GetType().GetProperties().ToList();

            for (int i = 0; i < lAuthor1Properties.Count; i++)
            {
                if (lAuthor1Properties[i].Attributes != lAuthor2Properties[i].Attributes)
                    return false;
            }

            return true;
        }

        #endregion
    }
}
