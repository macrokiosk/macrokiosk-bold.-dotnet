using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BOLD.Key
{
    class Program
    {
        static void Main(string[] args)
        {
            #region //SENDING BOLD.Key SMS OTP VIA REST HTTP GET
            var requestUri = string.Format(
                    "https://secure.etracker.cc/MobileOTPAPI/OTPGenerateAPI.aspx?user={0}&pass={1}&type={2}&to={3}&from={4}&text={5}&servid={6}",
                    "username",
                    "password",
                    "0",
                    "60123456789",
                    "from",
                    "BOLD.Key SMS OTP <OTPCode>",//<OTPCode> tag for system to generate OTP Code
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

            #region//VALIDATE BOLD.Key SMS OTP VIA REST HTTP GET
            var requestUri2 = string.Format(
                    "https://secure.etracker.cc/MobileOTPAPI/OTPVerifyAPI.aspx?user={0}&pass={1}&to={2}&from={3}&servid={4}&pincode={5}",
                    "username",
                    "password",
                    "60123456789",
                    "from",
                    "mes01",
                    "1111"//OTP Code received by mobile user
                    );

            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(requestUri2).Result)
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

            #region//SENDING BOLD.Key SMS OTP VIA REST HTTP POST
            //Serialize the object into JSON string
            string parameter = JsonConvert.SerializeObject(new
            {
                user = "username",
                pass = "password",
                type = "0",
                to = "60123456789",
                from = "from",
                text = "BOLD.Key SMS OTP <OTPCode>",
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

                using (var response = httpClient.PostAsync("https://secure.etracker.cc/MobileOTPAPI/SMSOTP/OTPGenerate", content).Result)
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

            #region//VALIDATE BOLD.Key SMS OTP VIA REST HTTP POST
            //Serialize the object into JSON string
            string parameter2 = JsonConvert.SerializeObject(new
            {
                user = "username",
                pass = "password",
                to = "60123456789",
                from = "from",
                servid = "serviceid",
                pincode = "1111"
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

                using (var response = httpClient.PostAsync("https://secure.etracker.cc/MobileOTPAPI/SMSOTP/OTPVerify", content).Result)
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
    }
}
