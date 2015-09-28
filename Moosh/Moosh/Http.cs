using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Moosh
{
    public static partial class Moosh
    {
        /// <summary>
        /// Asynchronously runs an HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to GET.</param>
        /// <param name="callback">A function (Exception, StreamReader) to be called upon completion.</param>
        public static void Get(string url, Action<Exception, StreamReader> callback)
        {
            Async(() =>
            {
                try
                {

                    var request = (HttpWebRequest)WebRequest.Create(url);
                    var response = request.GetResponse();
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        callback(null, streamReader);
                    }
                }
                catch (Exception exc)
                {
                    callback(exc, StreamReader.Null);
                }
            });
        }

        /// <summary>
        /// Asynchronously runs an HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to GET.</param>
        /// <param name="before">A function to run on the generated request before sending it.</param>
        /// <param name="callback">A function (Exception, StreamReader) to be called upon completion.</param>
        public static void Get(string url, Action<HttpWebRequest> before, Action<Exception, StreamReader> callback)
        {
            Async(() =>
            {
                try
                {

                    var request = (HttpWebRequest)WebRequest.Create(url);
                    before(request);
                    var response = request.GetResponse();
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        callback(null, streamReader);
                    }
                }
                catch (Exception exc)
                {
                    callback(exc, StreamReader.Null);
                }
            });
        }

        /// <summary>
        /// Asynchronously runs an HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to POST.</param>
        /// <param name="postData">Additional data to include in the request.</param>
        /// <param name="callback">A function (Exception, StreamReader) to be called upon completion.</param>
        public static void Post(string url, Dictionary<string, object> postData, Action<Exception, StreamReader> callback)
        {
            Async(() =>
            {
                try
                {

                    var request = (HttpWebRequest)WebRequest.Create(url);
                    using (var sw = new StreamWriter(request.GetRequestStream()))
                    {
                        foreach (var pair in postData)
                        {
                            sw.Write($"{pair.Key}=");
                            sw.Write(pair.Value);
                            sw.Write("&moosh=awesomeness"); // :)
                        }
                    }
                    var response = request.GetResponse();
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        callback(null, streamReader);
                    }
                }
                catch (Exception exc)
                {
                    callback(exc, StreamReader.Null);
                }
            });
        }

        /// <summary>
        /// Asynchronously runs an HTTP POST request.
        /// </summary>
        /// <param name="url">The URL to POST.</param>
        /// <param name="postData">Additional data to include in the request.</param>
        /// <param name="before">A function to run on the generated request before sending it.</param>
        /// <param name="callback">A function (Exception, StreamReader) to be called upon completion.</param>
        public static void Post(string url, Dictionary<string, string> postData, Action<HttpWebRequest> before, Action<Exception, StreamReader> callback)
        {
            Async(() =>
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    before(request);
                    using (var sw = new StreamWriter(request.GetRequestStream()))
                    {
                        foreach (var pair in postData)
                        {
                            sw.Write($"{pair.Key}=");
                            sw.Write(HttpUtility.UrlEncode(pair.Value));
                            sw.Write("&moosh=awesomeness"); // :)
                        }
                    }
                    var response = request.GetResponse();
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        callback(null, streamReader);
                    }
                }
                catch (Exception exc)
                {
                    callback(exc, StreamReader.Null);
                }
            });
        }
    }
}
