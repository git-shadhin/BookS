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
        ValidationError,
        SearchFail,
        NullReference
    }

    /// <summary>
    /// This class represent result of the database crud operation.
    /// </summary>
    public class ResultInfo<T> where T : class
    {
        public ResultStatus Status { get; set; }
        public string ResultMessage { get; set; }
        public Exception Exception { get; set; }
        public T Object { get; private set; }
        public string ObjectInfo { get; private set; }

        public IResultInfoDecorator Decorator { get; private set; }

        /// <summary>
        /// Constructor for the result of database operation. General purpose and object free constructor.
        /// Can be used when database query failed and null will be returned instead of wanted object.
        /// </summary>
        public ResultInfo()
            : this(null)
        {
        }

        /// <summary>
        /// Constructor for the result of database operation. Gets object which is related with performed query.
        /// </summary>
        public ResultInfo(T pObject, IResultInfoDecorator pDecorator = null)
        {
            Object = pObject;
            if(Object != null) PrepareObjectInfo();
            Decorator = pDecorator ?? new ResultInfoDecorator();
        }

        private void PrepareObjectInfo()
        {
            var info = new StringBuilder();

            info.Append("Operation result contains object: ").AppendLine(Object.GetType().FullName)
                .Append("From assembly: ").AppendLine(Object.GetType().Assembly.FullName)
                .Append("Object description below...").AppendLine()
                .AppendLine(Object.ToString());

            ObjectInfo = info.ToString();
        }
    }
}
