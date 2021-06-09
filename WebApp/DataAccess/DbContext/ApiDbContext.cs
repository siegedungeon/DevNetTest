using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiBack.Models;

namespace WebApiBack.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public virtual DbSet<Users> User { get;set;}

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
            
        }
    }
}