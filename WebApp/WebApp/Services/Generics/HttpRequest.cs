using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services.Generics
{
    public class HttpRequest<T>
    {
        public string apiUrl = string.Empty;
        public string ControllerString = string.Empty;
        public string token = string.Empty;
        public bool isLogin = false;
       
        public HttpRequest(string ApiUrl, string Controller, string Token ="",bool IsLogin=false)
        {
            apiUrl = ApiUrl;
            ControllerString = Controller;
            token = Token;
            isLogin = IsLogin;
        }



        public async Task<T> PostBasicAsync<P>(P content, HttpMethod method)
        {
           
            var uri = apiUrl + ControllerString;
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(method, uri))
            {
                var json = JsonConvert.SerializeObject(content);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    if (!isLogin)
                    {
                        request.Headers.Authorization= 
                            new AuthenticationHeaderValue("Bearer", token);
                    }
                    request.Content = stringContent;
                    

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                       
                       // response.EnsureSuccessStatusCode();

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var responseBody = await response.Content.ReadAsStringAsync();

                            var returnedObj = JsonConvert.DeserializeObject<T>(responseBody);

                            return returnedObj;
                        }
                        else
                        {
                            if (response.StatusCode == HttpStatusCode.BadRequest)
                            {
                                throw new Exception(response.Content.ToString());
                            }
                            else
                            {
                                throw new Exception("Comunication Issue");
                            }
                        }

                    }
                }
            }
        }
    }
}
