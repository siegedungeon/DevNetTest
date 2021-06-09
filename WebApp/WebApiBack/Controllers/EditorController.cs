using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApiBack.Data;
using WebApiBack.Models.DTOs;
using WebApiBack.Models.DTOs.Request;

namespace WebApiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {

        private readonly ApiDbContext _context;
        private readonly UserManager<AppUserBack> _userManager;

        public EditorController(ApiDbContext context, UserManager<AppUserBack> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "editor")]
        public async Task<IActionResult> getPendings()
        {
            var items = await _context.Article
                                       .Where(a => a.HasAproval == 0)  //All it is aproved
                                       .ToListAsync();
            return Ok(items);
        }

        [HttpPost("{id}")]
        [Authorize(Roles = "editor")]
        public async Task<IActionResult> Aprovals(long id, AproveArticleRequest model)
        {

            var existItem = await _context.Article.FirstOrDefaultAsync(x => x.ArticleId == id);
            var Author = await _context.User.FirstOrDefaultAsync(x => x.AuthorId == model.AuthorId);

            if (Author == null) { return NotFound("Author doesn't exist"); }

            if (existItem == null)
                return NotFound();

            existItem.HasAproval = 1;
            existItem.UserAprove = Author;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
