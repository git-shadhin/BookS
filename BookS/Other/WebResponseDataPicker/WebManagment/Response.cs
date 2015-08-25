using System;
using System.Net;

namespace WebResponseDataPicker.WebManagment
{
    /// <summary>
    /// This class contains information about response of the http request.
    /// </summary>
    public class Response
    {
        public string Message { get; set; }
        public string DetailedMessage { get; set; }
        public ResponseStatus Status { get; set; }
        public WebResponse WebResponse { get; set; }
        public Exception Exception { get; set; }
    }

    public enum ResponseStatus
    {
        Exception,
        UriError,
        HttpError,
        Success
    }
}
