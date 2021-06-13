using System.Threading.Tasks;
using WebApp.Models.DTOs.Response;
using WebApp.Models.Request.Login;

namespace WebApp.Services.Login
{
    public interface ILogin
    {
        public Task<LoginResponse> Validacion(LoginModel item);
    }
}
