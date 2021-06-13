using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Models.Request.Articles;

namespace WebApp.Services.Blog
{
    public interface IArticle
    {
        Task<List<Article>> GetAll();
        Task<Article> GetById(int id, string Token);
        Task<string> Update(int id, UpdateArticleDto model, string Token);
        Task<string> Delete(int id, string Token);
        Task<string> Create(CreateArticleRequest model, string Token);
    }
}
