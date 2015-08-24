using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebResponseDataPicker.WebManagment;

namespace Tests.WebResponseDataPicker
{
    [TestClass]
    public class TestHelper
    {
        private string[] mUrls;
        private string[] mUrlsWithPorts;

        [TestInitialize]
        public void Setup()
        {
            mUrls = new[]
            {
                "http://www.wp.pl",
                "www.wp.pl",
                "wp.pl",
                "www.wp.pl/",
                "https://www.wp.pl",
                "https://www.wp.pl/index.html"
            };

            mUrlsWithPorts = new[]
            {
                "http://www.wp.pl:0",
                "www.wp.pl:1",
                "wp.pl:2",
                "www.wp.pl:3/",
                "https://www.wp.pl:4",
                "https://www.wp.pl:5/index.html"
            };
        }

        [TestMethod]
        public void InsertPortToUrlTest()
        {
            string url = Helper.InsertPortNumberToUrl(mUrls[0], 800);
            Assert.AreEqual("http://www.wp.pl:800", url);

            url = Helper.InsertPortNumberToUrl(mUrls[1], 800);
            Assert.AreEqual("www.wp.pl:800", url);

            url = Helper.InsertPortNumberToUrl(mUrls[2], 800);
            Assert.AreEqual("wp.pl:800", url);

            url = Helper.InsertPortNumberToUrl(mUrls[3], 800);
            Assert.AreEqual("www.wp.pl:800/", url);

            url = Helper.InsertPortNumberToUrl(mUrls[4], 800);
            Assert.AreEqual("https://www.wp.pl:800", url);

            url = Helper.InsertPortNumberToUrl(mUrls[5], 800);
            Assert.AreEqual("https://www.wp.pl:800/index.html", url);

            foreach (string u in mUrlsWithPorts)
            {
                string tempUrl = Helper.InsertPortNumberToUrl(u, 800);
                Assert.AreEqual(u, tempUrl);
            }
        }

        [TestMethod]
        public void TestUrlContainsPort()
        {
            foreach (string url in mUrls)
            {
                Assert.IsFalse(Helper.UrlContainsPort(url));
            }

            foreach (string url in mUrlsWithPorts)
            {
                Assert.IsTrue(Helper.UrlContainsPort(url));
            }
        }

        [TestMethod]
        public void TestGetPortFromUrl()
        {
            foreach (string url in mUrls)
            {
                Assert.AreEqual(-1, Helper.GetPortFromUrl(url));
            }

            for (int i = 0; i < mUrlsWithPorts.Length; i++)
            {
                Assert.AreEqual(i, Helper.GetPortFromUrl(mUrlsWithPorts[i]));
            }
        }

        [TestMethod]
        public void TestUrlHasPortNumber()
        {
            for (int i = 0; i < mUrlsWithPorts.Length; i++)
            {
                Assert.IsTrue(Helper.UrlHasPortNumber(mUrlsWithPorts[i], i));
            }

            int[] ports = { 1, 2, 4, 500, 80, 8008, 443, 8080 };

            foreach (string url in mUrls)
            {
                var result = Helper.UrlHasPortNumber(url, ports);

                Assert.IsFalse(result.Any(x => x.Value == true));
            }

            string testUrl = "www.wp.pl:1";
            Assert.IsTrue(Helper.UrlHasPortNumber(testUrl, ports).First(x => x.Key == 1).Value == true);

            testUrl = "http://www.wp.pl:8080/?sad1da.html";
            Assert.IsTrue(Helper.UrlHasPortNumber(testUrl, ports).First(x => x.Key == 8080).Value == true);

            testUrl = "http://www.wp.pl:50/index.html";
            Assert.IsFalse(Helper.UrlHasPortNumber(testUrl, ports).Any(x => x.Value == true));
        }

        [TestMethod]
        public void TestSwitchPortNumber()
        {
            foreach (var url in mUrlsWithPorts)
            {
                string replacedUrl = Helper.SwitchPortNumber(url, 443);

                Assert.IsTrue(Helper.UrlHasPortNumber(replacedUrl, 443));
            }
        }
    }
}
