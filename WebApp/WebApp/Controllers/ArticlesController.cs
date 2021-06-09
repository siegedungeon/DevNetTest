using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Models.User;
using WebApp.Services.Blog;

namespace WebApp.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticle _context;
        private readonly UserManager<AppUser> _userManager;

        public ArticlesController(IArticle context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Article.Include(a => a.Author);
            //return View(await applicationDbContext.ToListAsync());
            return View();
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var article = await _context.Article
            //                            .Include(a => a.Author)
            //                            .SingleOrDefaultAsync(m => m.ArticleId == id);
            //if (article == null)
            //{
            //    return NotFound();
            //}

            //return View(article);
            return View();
        }

        // GET: Articles/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> Create([Bind("Title, Abstract,Contents")] Article article)
        {
            //if (ModelState.IsValid)
            //{
            //    article.AuthorId = _userManager.GetUserId(this.User);
            //    article.CreatedDate = DateTime.Now;
            //    _context.Add(article);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(article);
            return View();
        }

        // GET: Articles/Delete/5
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var article = await _context.Article.SingleOrDefaultAsync(m => m.ArticleId == id);
            //if (article == null)
            //{
            //    return NotFound();
            //}

            //return View(article);
            return View();
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var article = await _context.Article.SingleOrDefaultAsync(m => m.ArticleId == id);
            //_context.Article.Remove(article);
            //await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
