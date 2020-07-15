using System;
using System.Net.Http;

namespace BOLD.Pay.Agents
{
    public class WebRequestAgent
    {
        public static string HttpGet(string url, bool redirect)
        {
            string responseUrl = null;

            try
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.AllowAutoRedirect = redirect;

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (HttpRequestMessage httpRequestMsg = new HttpRequestMessage(HttpMethod.Get, url))
                    {
                        using (var response = httpClient.SendAsync(httpRequestMsg).Result)
                        {
                            responseUrl = response.Headers.Location.ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return responseUrl;
        }
    }
}