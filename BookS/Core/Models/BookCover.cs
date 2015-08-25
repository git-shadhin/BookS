using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Models.MappedClasses;

namespace BookS.Core.Models
{
    public class BookCover
    {
        #region Private Fields

        protected int mBookCoverId;

        #endregion

        #region Properties

        public int BookCoverId
        {
            get { return mBookCoverId; }
            set { mBookCoverId = value; }
        }

        #endregion
    }
}
