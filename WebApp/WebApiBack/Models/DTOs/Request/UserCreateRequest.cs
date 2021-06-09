using System.ComponentModel.DataAnnotations;

namespace WebApiBack.Models.DTOs.Request
{
    public class UserCreateRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Role { get; set; } //  Writer or Editor
    }
}
