using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BookS.Core.Maintenance;
using BookS.Core.Models.MappedClasses;
using BookS.Core.Repositories;
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

        #region

        public Author()
        {
            Validate();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject1"></param>
        /// <param name="pObject2"></param>
        /// <returns></returns>
        public bool? Compare(Author pObject1, Author pObject2)
        {
            if (pObject1 == null || pObject2 == null)
            {
                return null;
            }

            return CompareProperties(pObject1, pObject2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CompareProperties(Author pObject1, Author pObject2)
        {
            if (pObject1.AuthorId == pObject2.AuthorId)
                return true;

            
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder lDescription = new StringBuilder();



            return lDescription.ToString();
        }

        #endregion
    }
}
