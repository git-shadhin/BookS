using System;
using System.Collections.Generic;

namespace BookS.Core.Models.MappedClasses
{
    public class BookMapping
    {
        public virtual int BookId { get; set; }
        public virtual string Title { get; set; }
        public virtual string OriginalTitle { get; set; }
        public virtual string Isbn { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual int BookDetailId { get; set; }
        public virtual int CoverId { get; set; }
        public virtual IList<AuthorMapping> Authors { get; set; }
        public virtual IList<TranslatorMapping> Translators { get; set; }
        public virtual IList<GenreMapping> Genres { get; set; }
        public virtual int BorrowId { get; set; }
        public virtual int LendId { get; set; }
        public virtual int StorageId { get; set; }
    }
}
