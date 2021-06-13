using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Helpers;
using WebApp.Models.DTOs.Response;
using WebApp.Models.Request.Login;
using WebApp.Services.Generics;

namespace WebApp.Services.Login
{
    public class LoginService : ILogin
    {
        private readonly UrlApi _UrlApi;
        public LoginService(IOptionsMonitor<UrlApi> optionsMonitor)
        {
            _UrlApi = optionsMonitor.CurrentValue;
        }
        public async Task<LoginResponse> Validacion(LoginModel item)
        {
            HttpRequest<LoginResponse> http = new HttpRequest<LoginResponse>(_UrlApi.URI, "AuthManagement/Login", "",true);
            var response = await http.PostBasicAsync(item,HttpMethod.Post);
            return response;
        }
    }
}
