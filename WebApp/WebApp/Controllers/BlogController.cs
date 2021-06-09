using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Models.User;

namespace WebApp.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BlogController : Controller
    {
        private readonly SignInManager<AppUser> _sm;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public BlogController( SignInManager<AppUser> sm
            , UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            _sm = sm;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("account/logout")]
        public async Task<IActionResult> Logout()
        {
            await _sm.SignOutAsync();
            return Redirect("~/");
        }
    }
}

