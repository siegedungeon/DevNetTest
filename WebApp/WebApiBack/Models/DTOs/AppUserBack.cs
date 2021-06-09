using Microsoft.AspNetCore.Identity;

namespace WebApiBack.Models.DTOs
{
    public class AppUserBack : IdentityUser
    {
        public string AuthorId { get; set; }
        public string Role { get; set; }
    }
    public class RolesConstant
    {
        public string writer { get; set; } = "writer";
        public string editor { get; set; } = "editor";
    }
}
