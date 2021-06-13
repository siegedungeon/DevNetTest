using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models.Request.Articles;
using WebApp.Models.User;
using WebApp.Services.Blog;

namespace WebApp.Controllers
{
    
    public class ArticlesController : Controller
    {
        private IArticle _context;

        public ArticlesController(IArticle context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            //var token = getToken();
            var result = await _context.GetAll();
            return View(result);
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            var token = getToken();
            var article = await _context.GetById(id.Value,token);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        public IActionResult Create()
        {
            return View();
        }

       
        public async Task<IActionResult> CreatePost(CreateArticleRequest article)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            article.AuthorId = identity.FindFirst(ClaimTypes.Name).Value;
            article.CreatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                var token = getToken();
                await _context.Create(article, token);
                return RedirectToAction("Index");
            }
            return View(article);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var token = getToken();
            var article = await _context.GetById(id.Value, token);
            if (article == null)
            {
                return NotFound();
            }
            ViewBag.Id = article.ArticleId;
            return View(article);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var token = getToken();
            await _context.Delete(id, token);
            return RedirectToAction("Index");
        }

        private string getToken() 
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;

            var Name = identity.FindFirst(ClaimTypes.Authentication);
            return Name.Value;
        }

    }
}
