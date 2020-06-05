using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BOLD.Tag
{
    class Program
    {
        static void Main(string[] args)
        {
            #region//Logon API - To get Token
            //Serialize the object into JSON string
            string parameter = JsonConvert.SerializeObject(new
            {
                UserName = "username",
                Password = "password"
            });

            string tokenReturned;
            using (var httpClient = new HttpClient())
            {
                //Store the JSON string as the content to be sent to the web API.
                //Specify the HTTP Content-Type header as application/json
                //Specify application/xml if the content is in XML format
                var content = new StringContent(parameter);
                content.Headers.ContentType.MediaType = "application/json";

                //Assign the value of the Accept ("application/xml" or "application/json header
                //for an HTTP request in order to get the response in the desired format.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue
                ("application/json"));

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var response = httpClient.PostAsync("https://host.boldtag.net/api/ext/logon", content).Result)
                {
                    // by calling .Content a synchronous call will be performed
                    using (var responseContent = response.Content)
                    {
                        // by calling .Result the result will be read synchronously
                        var POSThttpContent = responseContent.ReadAsStringAsync().Result;

                        dynamic results = JsonConvert.DeserializeObject<dynamic>(POSThttpContent);
                        tokenReturned = results.token;
                    }

                    var POSThttpStatusCode = response.StatusCode;
                    var POSThttpStatusDescription = response.ReasonPhrase;
                }
            }
            #endregion

            #region//Dispatch API - To send SMS
            //Serialize the object into JSON string
            string parameter2 = JsonConvert.SerializeObject(new
            {
                ActivityKey = "7Oub6Apzu4EGvI3XD9OkmQyncXToEAAA", //Valid ActivityKey which configured at BOLD.Tag portal
                PredefinedValues = new Recepient { Name = "Max", Email = "60123456789" },
            });

            using (var httpClient = new HttpClient())
            {
                //Store the JSON string as the content to be sent to the web API.
                //Specify the HTTP Content-Type header as application/json
                //Specify application/xml if the content is in XML format
                var content = new StringContent(parameter2);
                content.Headers.ContentType.MediaType = "application/json";                
                
                //Assign the value of the Accept ("application/xml" or "application/json header
                //for an HTTP request in order to get the response in the desired format.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue
                ("application/json"));
                httpClient.DefaultRequestHeaders.Add("token", tokenReturned);//Token returned from Logon API

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var response = httpClient.PostAsync("https://host.boldtag.net/api/ext/Dispatch", content).Result)
                {
                    // by calling .Content a synchronous call will be performed
                    using (var responseContent = response.Content)
                    {
                        // by calling .Result the result will be read synchronously
                        var POSThttpContent = responseContent.ReadAsStringAsync().Result;
                    }

                    var POSThttpStatusCode = response.StatusCode;
                    var POSThttpStatusDescription = response.ReasonPhrase;
                }
            }
            #endregion
        }

        public class Recepient
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("MobileNo")]
            public string Email { get; set; }
        }
    }
}
