using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebResponseDataPicker.WebManagment
{
    public enum HttpPort
    {
        Default = 80,
        Secure = 443,
        Alternate = 8008,
        Proxy = 8080
    }

    public enum WebManagementExceptionType
    {
        
    }

    public static class Helper
    {
        #region Url

        /// <summary>
        /// This method inserts port number to given url address if it hasn't any port number assinged.
        /// </summary>
        /// <returns>Url with specified port address</returns>
        public static string InsertPortNumberToUrl(string pUrl, int pPort)
        {
            if (!UrlContainsPort(pUrl))
            {
                InsertPort(ref pUrl, pPort);
            }

            return pUrl;
        }

        private static void InsertPort(ref string pUrl, int pPort)
        {
            int matchPosition = DeterminePortPositionInUrl(pUrl);
            pUrl = pUrl.Insert(matchPosition, ":" + pPort);
        }

        private static int DeterminePortPositionInUrl(string pUrl)
        {
            Regex portNumberRegex = new Regex(@"[a-zA-Z]{1,}\.[a-zA-Z]{2,3}(?=$|[\/])");
            Match urlPortMatch = portNumberRegex.Match(pUrl);

            return urlPortMatch.Index + urlPortMatch.Length;
        }

        /// <summary>
        /// This method checks if port number is inserted in url address.
        /// </summary>
        /// <returns>True if port number is located in url address and false otherwise</returns>
        public static bool UrlContainsPort(string pUrl)
        {
            return Regex.IsMatch(pUrl, @"(?<=.\..[a-zA-Z]:)\d*(?=.*$)");
        }

        /// <summary>
        /// This method checks if given port number is located in given url address.
        /// </summary>
        /// <returns>True if one of the given port number exists and false otherwise</returns>
        public static bool UrlHasPortNumber(string pUrl, int pPortNumber)
        {
            return UrlHasPortNumber(pUrl, new[] { pPortNumber })[pPortNumber];
        }

        /// <summary>
        /// This method checks if one of given port numbers is located in given url address.
        /// </summary>
        /// <returns>Dictionary containing information if given port numbers is contained in given url address</returns>
        public static Dictionary<int, bool> UrlHasPortNumber(string pUrl, params int[] pPortNumbers)
        {
            var port = GetPortFromUrl(pUrl);
            return pPortNumbers.ToDictionary(portNumber => portNumber, portNumber => port == portNumber);
        }

        /// <summary>
        /// This method gets port number from given url address.
        /// </summary>
        /// <returns>Port number in url address or -1 if url doesn't contain port number</returns>
        public static int GetPortFromUrl(string pUrl)
        {
            var regex = new Regex(@"(?<=.\..[a-zA-Z]:)\d*(?=.*$)");
            var match = regex.Match(pUrl);

            if (match.Captures.Count != 0)
                return int.Parse(match.Captures[0].Value);

            return -1; // means no port number in url address
        }

        /// <summary>
        /// This method switches port number in specified url address.
        /// </summary>
        /// <returns></returns>
        public static string SwitchPortNumber(string pUrl, int pPort)
        {
            var regex = new Regex(@"(?<=.\..[a-zA-Z]:)\d*(?=.*$)");
            return regex.Replace(pUrl, pPort.ToString());
        }

        #endregion

        #region Retrieving data from XML file

        /// <summary>
        /// This method gets data from xml file containing exception message for given exception type. 
        /// </summary>
        /// <returns>Tuble object containing pair of exception messages (basic info and detailed message) </returns>
        public static Tuple<string, string> GetExceptionMessage(WebManagementExceptionType pExceptionType)
        {
            
        }

        #endregion
    }
}
