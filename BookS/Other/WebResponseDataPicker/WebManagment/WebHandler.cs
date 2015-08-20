using System;
using System.Net;

namespace WebResponseDataPicker.WebManagment
{
    public sealed class WebHandler
    {
        private readonly WebRequestCreator mRequestCreator;
        private readonly WebResponseReceiver mResponseReceiver;

        public WebHandler()
        {
            mRequestCreator = new WebRequestCreator();
            mResponseReceiver = new WebResponseReceiver();
        }

        public Response SendHttpRequest(string pUrl)
        {
            return SendHttpRequest(pUrl, HttpPort.Default);
        }

        public Response SendHttpRequest(string pUrl, HttpPort pPort)
        {
            Request request = mRequestCreator.CreateRequest(pUrl, pPort);
            return mResponseReceiver.GetResponse(request);
        }

        // TODO response from IP ?
    }
}
