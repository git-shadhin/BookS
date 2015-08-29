using System;
using System.Collections.Generic;

namespace BookS.Core.Models.MappedClasses
{
    internal class BookMapping : Book
    {
        new public virtual int BookId
        {
            get { return mBookId; }
            set { base.BookId = value; }
        }

        new public virtual string Title
        {
            get { return mTitle; } 
            set { base.Title = value; }
        }

        new public virtual string OriginalTitle
        {
            get { return mOriginalTitle; } 
            set { base.OriginalTitle = value; }
        }

        public new virtual string Isbn
        {
            get { return mIsbn.Number; }
            set { AssignIsbn(value); }
        }

        new public virtual DateTime CreationDate
        {
            get { return mCreationDate; } 
            set { base.CreationDate = value; }
        }

        public virtual int BookDetailId
        {
            get { return BookDetails.BookDetailsId; } 
            set { AssignBookDetails(value); }
        }

        public virtual int CoverId
        {
            get { return Cover.BookCoverId; } 
            set { AssignBookCover(value); }
        }

        new public virtual IList<AuthorMapping> Authors
        {
            get { return base.Authors as IList<AuthorMapping>; } 
            set { base.Authors = value as IList<Author>; }
        }

        new public virtual IList<TranslatorMapping> Translators
        {
            get { return base.Translators as IList<TranslatorMapping>; } 
            set { base.Translators = value as IList<Translator>; }
        }

        new public virtual IList<GenreMapping> Genres
        {
            get { return base.Genres as IList<GenreMapping>; } 
            set { base.Genres = value as IList<Genre>; }
        }

        new public virtual int BorrowId
        {
            get { return mBorrowId; } 
            set { base.BorrowId = value; }
        }

        new public virtual int LendId
        {
            get { return mLendId; } 
            set { base.LendId = value; }
        }

        new public virtual int StorageId
        {
            get { return mStorageId; } 
            set { base.StorageId = value; }
        }
    }
}
