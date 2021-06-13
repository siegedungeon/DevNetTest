using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiBack.Models;

namespace WebApiBack.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public virtual DbSet<IdentityUser> User { get;set;}

        public virtual DbSet<Article> Article { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
            
        }
    }
}