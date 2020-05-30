using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using BOLD.Console.SoapService;
using System.Collections.Generic;

namespace BOLD.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region //SENDING SMS VIA REST HTTP GET
            var requestUri = string.Format(
                    "https://www.etracker.cc/bulksms/send?user={0}&pass={1}&type={2}&to={3}&from={4}&text={5}&servid={6}",
                    "username",
                    "password",
                    "0",
                    "60123456789",
                    "from",
                    "test",
                    "serviceid");

            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(requestUri).Result)
                {
                    // by calling .Content a synchronous call will be performed
                    using (var responseContent = response.Content)
                    {
                        // by calling .Result the result will be read synchronously 
                        var GEThttpContent = responseContent.ReadAsStringAsync().Result;
                    }

                    var GEThttpStatusCode = response.StatusCode;
                    var GEThttpStatusDescription = response.ReasonPhrase;
                }
            }
            #endregion

            #region//SENDING SMS VIA REST HTTP POST
            //Serialize the object into JSON string
            string parameter = JsonConvert.SerializeObject(new
            {
                user = "username",
                pass = "password",
                type = "0",
                to = "60123456789",
                from = "from",
                text = "test",
                servid = "serviceid"
            });

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

                using (var response = httpClient.PostAsync("https://www.etracker.cc/bulksms/send", content).Result)
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

            #region//SENDING SMS VIA SOAP WEB SERVICE
            using (var proxy = new SoapServiceClient())
            {
                var soapParam = new SoapParam
                {
                    Username = "username",
                    Password = "password",
                    MessageType = "0",
                    Msisdn = "60123456789",
                    From = "from",
                    Text = "test",
                    ServiceID = "serviceid"
                };
                proxy.Send(soapParam);
            }
            #endregion

            #region//SENDING EMAIL VIA HTTP POST
            List<Recipient> sendList = new List<Recipient>();
            sendList.Add(new Recipient { Name = "Recipient", Email = "Recipient@macrokiosk.com" });

            string emailParameter = JsonConvert.SerializeObject(new
            {
                to = sendList,
                sender = new Sender { Name = "Sender", Email = "Sender@macrokiosk.com" },
                htmlContent = "Email Test Content",
                subject = "Email Test Subject",
                replyTo = new Sender { Name = "ReplyTo", Email = "ReplyTo@macrokiosk.com" },
                username = "username",
                password = "password",
                serviceId = "serviceID",
                IsHashed = false
            });
                        
            using (var httpClient = new HttpClient())
            {
                //Store the JSON string as the content to be sent to the web API.
                //Specify the HTTP Content-Type header as application/json
                //Specify application/xml if the content is in XML format
                var emailContent = new StringContent(emailParameter);
                emailContent.Headers.ContentType.MediaType = "application/json";

                //Assign the value of the Accept ("application/xml" or "application/json header
                //for an HTTP request in order to get the response in the desired format.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue
                ("application/json"));

                using (var response = httpClient.PostAsync("https://www.etracker.cc/BulkEmail/Send", emailContent).Result)
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
            }            #endregion
        }

        public class Sender
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
        }

        public class Recipient
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
        }
    }
}
