using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebResponseDataPicker.WebManagment;

namespace Tests.WebResponseDataPicker
{
    [TestClass]
    public class TestWebHandler
    {
        private WebHandler mWebHandler;
        private string[] mCorrectUrls;
        private string[] mWrongUrls;

        [TestInitialize]
        public void Setup()
        {
            mWebHandler = new WebHandler();

            mCorrectUrls = new[]
            {
                "http://www.wp.pl",
                "www.wp.pl",
                "wp.pl",
                "www.wp.pl/",
                "https://www.wp.pl",
                "https://www.wp.pl/index.html"
            };

            mWrongUrls = new []
            {
                "http://ww.wp.pl",
                "htp://www.wp.pl",
                "http:/www.wp.pl",
                "http://www.wp",
                "http://www.wp.pl.",
                "www.wp.pl//",
                "ww.wp.pl"
                //TODO check unallowed url symbols
            };
        }

        [TestMethod]
        public void WrongUrlResponse()
        {
            foreach (string url in mWrongUrls)
            {
                Response response = mWebHandler.SendHttpRequest(url);

                Assert.AreEqual(string.Format("Given Uri {0} has wrong format!", url), response.Message);
                Assert.AreEqual(ResponseStatus.UriError, response.Status);
                Assert.AreEqual(string.Format("The Url address {0} is not correct", url) ,response.DetailedMessage);
            }
        }

        [TestMethod]
        public void WrongPortAppendedToUrl()
        {
            foreach (string url in mCorrectUrls)
            {
                //TODO use regex to add port number into url
                string urlWithPort = url + ":60";

                Response response = mWebHandler.SendHttpRequest(urlWithPort);

                Assert.AreEqual(string.Format("Given Uri {0} has wrong format!", urlWithPort), response.Message);
                Assert.AreEqual(ResponseStatus.UriError, response.Status);
                Assert.AreEqual(string.Format("The Url address {0} is not correct", url), response.DetailedMessage);
            }
        }

        [TestMethod]
        public void UrlPortNotEqualsArgumentHttpPort()
        {
            
        }

        [TestMethod]
        public void CorrectUriResponseOnDefaultPort()
        {

        }

        [TestMethod]
        public void CorrectUriResponseOnHttpsPort()
        {

        }

        [TestMethod]
        public void CorrectUriResponseOnAlternatePort()
        {

        }

        [TestMethod]
        public void InvalidProxyFor8080Port()
        {

        }

        [TestMethod]
        public void CorrectUriResponseOnProxyPort()
        {

        }
    }
}
