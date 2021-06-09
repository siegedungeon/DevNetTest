using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services.Generics
{
    public class HttpRequest<T>
    {
        public string apiUrl = string.Empty;
        public string ControllerString = string.Empty;

        public HttpRequest(string ApiUrl, string Controller)
        {
            apiUrl = ApiUrl;
            ControllerString = Controller;
        }

        public async Task<T> PostBasicAsync<P>(P content)
        {
            var uri = apiUrl + ControllerString;
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                var json = JsonConvert.SerializeObject(content);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
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
                                string Res = response.Content.ToString();
                                Res.Remove(1, 11).Replace('\"', ' ').Replace("{", " ").Replace("}", "").Trim();
                                throw new Exception(Res);
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
