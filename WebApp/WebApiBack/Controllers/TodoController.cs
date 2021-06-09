using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiBack.Data;
using WebApiBack.Models;
using WebApiBack.Models.DTOs.Request;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TodoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TodoController(ApiDbContext context)
        {   
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _context.Article
                                        .Where(a=>a.HasAproval==1)  //All it is aproved
                                        .ToListAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(ArticleRequestCreate data)
        {
            if(ModelState.IsValid)
            {
                var Author = await _context.User.FirstOrDefaultAsync(x => x.AuthorId == data.AuthorId);

                if (Author == null) { return NotFound("Author doesn't exist"); }

                var response=  await _context.Article.AddAsync(new Article() { 
                    Abstract=data.Abstract,
                    Author= Author,
                    Contents=data.Contents,
                    CreatedDate=data.CreatedDate,
                    Title=data.Title
                });
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetItem", new {response.Entity.ArticleId }, data);
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

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            var existItem = await _context.Article.FirstOrDefaultAsync(x => x.ArticleId == id);

            if(existItem == null)
                return NotFound();

            _context.Article.Remove(existItem);
            await _context.SaveChangesAsync();

            return Ok(existItem);
        }

    }
}