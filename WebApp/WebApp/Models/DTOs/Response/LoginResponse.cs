using System.Collections.Generic;

namespace WebApp.Models.DTOs.Response
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
