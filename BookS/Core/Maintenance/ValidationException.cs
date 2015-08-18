using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookS.Core.Maintenance
{
    /// <summary>
    /// Represents error that occur during object validation process.
    /// </summary>
    public class ValidationException : Exception
    {
        public string ValidationMessage { get; private set; }
        public ValidationStatus Status { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pStatus"></param>
        public ValidationException(ValidationStatus pStatus) : this(String.Empty, pStatus, String.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pStatus"></param>
        public ValidationException(string pMessage, ValidationStatus pStatus) : this(pMessage, pStatus, String.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pStatus"></param>
        /// <param name="pValidationMessage"></param>
        public ValidationException(string pMessage, ValidationStatus pStatus, string pValidationMessage) : base(pMessage)
        {
            ValidationMessage = pValidationMessage;
            Status = pStatus;
        }
    }
}
