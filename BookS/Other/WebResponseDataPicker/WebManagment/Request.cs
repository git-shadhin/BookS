using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebResponseDataPicker.WebManagment
{
    public class Request
    {
        public string Message { get; set; }
        public string DetailedMessage { get; set; }
        public RequestStatus Status { get; set; }
        public WebRequest WebRequest { get; set; }
    }

    public enum RequestStatus
    {
        
    }
}
