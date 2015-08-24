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
            Request request = mRequestCreator.CreateRequest(pUrl);
            return mResponseReceiver.GetResponse(request);
        }

        public Response SendHttpRequest(IPAddress pIpAddress)
        {
            Request request = mRequestCreator.CreateRequest(pIpAddress);
            return mResponseReceiver.GetResponse(request);
        }
    }
}
