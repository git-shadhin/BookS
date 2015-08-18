using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookS.Core.Maintenance
{
    public enum ResultStatus
    {
        Success,
        UpdateFail,
        CreationFail,
        DeleteFail,
        InnerException,
        NullReference
    }

    /// <summary>
    /// This class represent result of the database crud operation.
    /// </summary>
    public class ResultInfo<T>
    {
        public ResultStatus Status { get; set; }
        public string ExceptionMessage { get; set; }
        public string ResultMessage { get; set; }
        public T Object { get; private set; }

        /// <summary>
        /// Constructor gets object which is used to perform database operation.
        /// </summary>
        public ResultInfo(T pObject)
        {
            Object = pObject;
        }
    }
}
