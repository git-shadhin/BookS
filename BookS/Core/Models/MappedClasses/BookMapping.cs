using System;
using System.Collections.Generic;

namespace BookS.Core.Models.MappedClasses
{
    public class BookMapping
    {
        protected virtual int BookId { get; set; }
        protected virtual string Title { get; set; }
        protected virtual string OriginalTitle { get; set; }
        protected virtual string Isbn { get; set; }
        protected virtual DateTime CreationDate { get; set; }
        protected virtual int BookDetailId { get; set; }
        protected virtual int CoverId { get; set; }
        protected virtual IList<AuthorMapping> Authors { get; set; }
        protected virtual IList<TranslatorMapping> Translators { get; set; }
        protected virtual IList<GenreMapping> Genres { get; set; }
        protected virtual int BorrowId { get; set; }
        protected virtual int LendId { get; set; }
        protected virtual int StorageId { get; set; }
    }
}
