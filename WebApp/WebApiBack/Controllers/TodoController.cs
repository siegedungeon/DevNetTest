using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiBack.Data;
using WebApiBack.Models;
using WebApiBack.Models.DTOs;
using WebApiBack.Models.DTOs.Request;
using WebApiBack.Models.DTOs.Response;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private  ApiDbContext _context;

        public TodoController(ApiDbContext context)
        {   
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetItems()
        {

            var resul = await (from ar in _context.Article
                         join usu in _context.Users on ar.AuthorId equals usu.Id 
                            where ar.HasAproval == 1
                            select new {
                                Abstract = ar.Abstract,
                                ArticleId = ar.ArticleId,
                                Contents = ar.Contents,
                                CreatedDate = ar.CreatedDate,
                                Title = ar.Title,
                                AuthorId = ar.AuthorId,
                                Email = usu.Email,
                                Name = usu.UserName,
                                HasAproval = ar.HasAproval,
                            }).ToListAsync();

            return Ok(resul);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(ArticleRequestCreate data)
        {
            if(ModelState.IsValid)
            {
                var Author = await _context.Users.FirstOrDefaultAsync(x => x.Id == data.AuthorId);

                if (Author == null) { return NotFound("Author doesn't exist"); }

                await _context.Article.AddAsync(new Article() { 
                    Abstract=data.Abstract,
                    Author= Author,
                    Contents=data.Contents,
                    CreatedDate=data.CreatedDate,
                    Title=data.Title
                });
                await _context.SaveChangesAsync();

                return Ok();
            }

            return new JsonResult("Something went wrong") {StatusCode = 500};
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _context.Article.FirstOrDefaultAsync(x => x.ArticleId == id);

            if(item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(UpdateArticleRequest item)
        {
           
            var existItem = await _context.Article.FirstOrDefaultAsync(x => x.ArticleId == item.ArticleId);

            if(existItem == null)
                return NotFound();

            existItem.Title = item.Title;
            existItem.Contents = item.Contents;
            existItem.Abstract = item.Abstract;
            
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            var existItem = await _context.Article.FirstOrDefaultAsync(x => x.ArticleId == id);

            if(existItem == null)
                return NotFound();

            _context.Article.Remove(existItem);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}