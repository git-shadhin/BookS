using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebResponseDataPicker.WebManagment
{
    /// <summary>
    /// Exception containing information about an error occured in any of the class used for WebManagment.
    /// </summary>
    public class WebResponseException : Exception
    {
        public ResponseStatus Status { get; private set; }
        public string ResponseMessage { get; private set; }
        public string DetailedResponseMessage { get; private set; }
        public WebResponse WebResponse { get; private set; }

        public WebResponseException(WebManagementExceptionType pExceptionNumber, ResponseStatus pStatus, WebResponse pWebResponse)
        {
            Status = pStatus;
            WebResponse = pWebResponse;

            var exceptionMessage = Helper.GetExceptionMessage(pExceptionNumber);

            ResponseMessage = exceptionMessage.Item1;
            DetailedResponseMessage = exceptionMessage.Item2;
        }
    }
}
