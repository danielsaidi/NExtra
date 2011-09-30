using System.IO;
using System.Net;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.Net.WebRequest.
    /// </summary>
    /// <todo>
    /// AdjustContent should also handle non-absolute, local paths.
    /// </todo>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class WebRequestExtensions
    {
        /// <summary>
        /// Adjust content that has been received from a web request.
        /// </summary>
        /// <param name="webRequest">The web request.</param>
        /// <param name="content">The content to adjust.</param>
        /// <returns>The adjusted content.</returns>
        public static string AdjustContent(this WebRequest webRequest, string content)
        {
            content = content.Replace("\r", "");
            content = content.Replace("\n", "");
            content = content.Replace("src=\"/", "src=\"" + webRequest.RequestUri.GetRootUri());
            content = content.Replace("href=\"/", "href=\"" + webRequest.RequestUri.GetRootUri());

            return content;
        }


        /// <summary>
        /// Get the response string (the content) of a web request.
        /// </summary>
        /// <param name="webRequest">The web request.</param>
        /// <returns>The content of the web request.</returns>
        public static string GetResponseString(this WebRequest webRequest)
        {
            var response = webRequest.GetResponse();
            if (response == null)
                return string.Empty;

            var responseStream = response.GetResponseStream();
            if (responseStream == null)
                return string.Empty;

            string result;
            using (var sr = new StreamReader(responseStream))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }

            return result;
        }
    }
}
