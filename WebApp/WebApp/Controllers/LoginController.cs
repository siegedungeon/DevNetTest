using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models.Request.Login;
using WebApp.Services.Login;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(LoginModel item)
        {
            try
            {
                var response = await _login.Validacion(item);

                var Claims = new List<Claim>();

                Claims.Add(new Claim(ClaimTypes.Email, item.Email));
                Claims.Add(new Claim(ClaimTypes.Authentication, response.Token));
                Claims.Add(new Claim(ClaimTypes.Name, response.AuthorId));


                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                identity.AddClaims(Claims);

                var authProperties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                };
                var principal = new ClaimsPrincipal(new ClaimsIdentity(identity));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                      new ClaimsPrincipal(principal),
                      authProperties);
                return Redirect("/");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

    }
}
