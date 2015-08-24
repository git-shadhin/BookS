using System.Net;

namespace WebResponseDataPicker.WebManagment
{
    /// <summary>
    /// 
    /// </summary>
    public class Response
    {
        public string Message { get; set; }
        public string DetailedMessage { get; set; }
        public ResponseStatus Status { get; set; }
        public WebResponse WebResponse { get; set; }
    }

    public enum ResponseStatus
    {
        UriError,
        HttpError,
        Success
    }
}
