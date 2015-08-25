using System;

namespace WebResponseDataPicker.WebManagment
{
    /// <summary>
    /// This class allows to send http request to website in order to obtain its raw html data.
    /// </summary>
    public sealed class WebHandler
    {
        private readonly WebRequestCreator mRequestCreator;
        private readonly WebResponseReceiver mResponseReceiver;

        public WebHandler()
        {
            mRequestCreator = new WebRequestCreator();
            mResponseReceiver = new WebResponseReceiver();
        }

        /// <summary>
        /// This method sends out http request to obtain raw html
        /// from website page which address is given as a parameter.
        /// </summary>
        /// <param name="pWebSiteAddress">URI address or IP of the website</param>
        /// <returns>Response object containing result of http request</returns>
        public Response SendHttpRequest(string pWebSiteAddress)
        {
            try
            {
                Request request = mRequestCreator.CreateRequest(pWebSiteAddress);
                return mResponseReceiver.GetResponse(request);
            }
            catch (WebResponseException ex)
            {
                return new Response
                {
                    Status = ex.Status,
                    Message = ex.ResponseMessage,
                    DetailedMessage = ex.DetailedResponseMessage,
                    WebResponse = ex.WebResponse
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Status = ResponseStatus.Exception,
                    Exception = ex
                };
            }
        }
    }
}
