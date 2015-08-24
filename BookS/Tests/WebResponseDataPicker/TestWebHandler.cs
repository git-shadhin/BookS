using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;
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
                "https://www.wp.pl/index.html",
                "www.wp.pl:80",
                "wp.pl:80/index.html"
            };

            mWrongUrls = new []
            {
                "http://ww.wp.pl",
                "htp://www.wp.pl",
                "http:/www.wp.pl",
                "http://www.wp",
                "http://www.wp.pl.",
                "www.wp.pl//",
                "ww.wp.pl",
                "www.!wp.pl",
                "www.wp.pl?",
                "wp.@pl",
                "www.().pl",
                "http://www.#/wp.pl",
                "www.wp.pl:"
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
                Assert.AreEqual(string.Format("The Url address {0} is not correct", url), response.DetailedMessage);
            }
        }

        [TestMethod]
        public void WrongPortInsertedInUrl()
        {
            foreach (string url in mCorrectUrls)
            {
                string urlWithPort = !Helper.UrlContainsPort(url) ? Helper.InsertPortNumberToUrl(url, 60) : Helper.SwitchPortNumber(url, 60);

                Response response = mWebHandler.SendHttpRequest(urlWithPort);

                Assert.AreEqual(string.Format("Given Uri {0} has wrong format!", urlWithPort), response.Message);
                Assert.AreEqual(ResponseStatus.UriError, response.Status);
                Assert.AreEqual(string.Format("The port number {0} is not correct", 60), response.DetailedMessage);
            }
        }
        
        [TestMethod]
        public void CorrectUriResponseOnDefaultPort()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CorrectUriResponseOnHttpsPort()
        {
            Assert.Fail();
        }
    }
}
