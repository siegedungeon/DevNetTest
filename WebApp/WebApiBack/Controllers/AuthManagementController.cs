using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiBack.Configuration;
using WebApiBack.Data;
using WebApiBack.Models.DTOs.Request;
using WebApiBack.Models.DTOs.Requests;
using WebApiBack.Models.DTOs.Responses;

namespace WebApiBack.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthManagementController(
            UserManager<IdentityUser> userManager,
            IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest _user)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = _user.Username, Email = _user.Email};
                var result = await _userManager.CreateAsync(user, _user.Password);
                await _userManager.AddToRoleAsync(user,_user.Role);

                return result.Succeeded ? Ok() : BadRequest("Process failed");
            }
            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid Model"
                    },
                Success = false
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if(ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if(existingUser == null) {
                        return BadRequest(new RegistrationResponse(){
                            Errors = new List<string>() {
                                "Invalid login request"
                            },
                            Success = false
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                if(!isCorrect) {
                      return BadRequest(new RegistrationResponse(){
                            Errors = new List<string>() {
                                "Invalid login request"
                            },
                            Success = false
                    });
                }

                var jwtToken  =GenerateJwtToken(existingUser);

                return Ok(new RegistrationResponse() {
                    Success = true,
                    Token = jwtToken
                });
            }

            return BadRequest(new RegistrationResponse(){
                    Errors = new List<string>() {
                        "Invalid payload"
                    },
                    Success = false
            });
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim("Id", user.Id), 
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}