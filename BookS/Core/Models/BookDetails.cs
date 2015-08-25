using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookS.Core.Models
{
    public class BookDetails
    {
        #region Private Fields

        protected int mBookDetailsId;

        #endregion

        #region Properties

        public int BookDetailsId
        {
            get { return mBookDetailsId; }
            set { mBookDetailsId = value; }
        }

        #endregion
    }
}
