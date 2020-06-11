using System;
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
            }
            #endregion

            #region//SENDING MMS VIA HTTP POST
            //Assign values to variables
            string user = "username";
            string password = "password";
            string serviceid = "serviceid";
            string subject = "MMS Title";
            string text = "MMS Text Message";
            string recipients = JsonConvert.SerializeObject(new string[] { "60103456789", "60123456789" });
            string iscontenturi = "1";
            string MMSContent = null;

            if (iscontenturi == "0")
            {
                //The below bytes value is only an example. Replace it if your content is in bytes.
                MMSContent = JsonConvert.SerializeObject(new byte[] { 0x01, 0x9A, 0x3D, 0x23, 0xAB, 0x5A });
            }
            else if (iscontenturi == "1")
            {
                MMSContent = JsonConvert.SerializeObject(@"http://res.cloudinary.com/demo/image/upload/v1525209117/folder1/folder2/sample.jpg");
            }

            //"0" represents file type jpg. [0 = jpg], [1 = jpeg], [2 = png], [3 = bmp], [4 = gif], [11 = mp3], [12 = mid], [13 = midi], [14 = wav], [15 = amr], [21 = mp4], [22 = 3gp]
            string multimediafiletype = "0";

            //Multipart Form Data. Each MultipartFormDataContentshould have the string name as specified.
            MultipartFormDataContent mContent = new MultipartFormDataContent();
            mContent.Add(new StringContent(user), "user");
            mContent.Add(new StringContent(password), "password");
            mContent.Add(new StringContent(serviceid), "serviceid");
            mContent.Add(new StringContent(subject), "subject");
            mContent.Add(new StringContent(text), "text");
            mContent.Add(new StringContent(recipients), "recipients");
            mContent.Add(new StringContent(iscontenturi), "iscontenturi");
            mContent.Add(new StringContent(MMSContent), "content");
            mContent.Add(new StringContent(multimediafiletype), "multimediafiletype");

            string url = "http://mms.etracker.cc/MMSWebAPI/api/BulkMMS/";
            string requestID = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{url}{requestID}");
            req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
            req.Content = mContent;

            HttpClient httpClientMMS = new HttpClient();

            using (var response = httpClientMMS.SendAsync(req).Result)
            {
                var statusCode = response.StatusCode;
                var message = response.ReasonPhrase;
            }
            #endregion 
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
