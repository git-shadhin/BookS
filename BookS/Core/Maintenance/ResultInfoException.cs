using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookS.Core.Maintenance
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultInfoException<T> : Exception
    {
        public ResultStatus Status { get; private set; }
        public string ResultMessage { get; private set; }
        public string ObjectInfo { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pResult"></param>
        public ResultInfoException(ResultInfo<T> pResult) : base(pResult.ExceptionMessage)
        {
            Status = pResult.Status;
            ResultMessage = pResult.ResultMessage;
            ObjectInfo = pResult.Object.ToString();
        }
    }
}
