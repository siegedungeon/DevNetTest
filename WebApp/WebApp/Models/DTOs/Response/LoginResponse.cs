using System.Collections.Generic;

namespace WebApp.Models.DTOs.Response
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Role { get; set; }
        public string AuthorId { get; set; }
        public List<string> Errors { get; set; }
    }
}
