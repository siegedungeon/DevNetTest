using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiBack.Models;
using WebApiBack.Models.DTOs;

namespace WebApiBack.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public virtual DbSet<AppUserBack> User { get;set;}

        public virtual DbSet<Article> Article { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
            
        }
    }
}