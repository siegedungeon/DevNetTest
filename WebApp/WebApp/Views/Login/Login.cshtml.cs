using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models.User;

namespace WebApp.Pages.Login
{
    public class LoginModel : PageModel
    {
        [Required]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        SignInManager<AppUser> _sm;

        public LoginModel(SignInManager<AppUser> sm)
        {
            _sm = sm;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync([FromQuery] string returnUrl = null)
        {
            
            return Page();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {           
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("~/");
            }
        }
    }
}
