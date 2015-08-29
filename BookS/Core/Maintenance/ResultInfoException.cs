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
        where T : class
    {
        public ResultInfo<T> Result { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pResult"></param>
        public ResultInfoException(ResultInfo<T> pResult)
        {
            Result = pResult;
        }
    }
}
