using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Models.Request.Articles;
using WebApp.Services.Generics;

namespace WebApp.Services.Blog
{
    public class ArticleService : IArticle
    {
        private readonly UrlApi _UrlApi;
        public ArticleService(IOptionsMonitor<UrlApi> optionsMonitor)
        {
            _UrlApi = optionsMonitor.CurrentValue;
        }
        public async Task<List<Article>> GetAll()
        {
            HttpRequest<List<Article>> http = new HttpRequest<List<Article>>(_UrlApi.URI, "Todo");
            var response = await http.PostBasicAsync("",HttpMethod.Get);
            return response;
        }
        public async Task<Article> GetById(int id, string Token)
        {
            HttpRequest<Article> http = new HttpRequest<Article>(_UrlApi.URI, "Todo/"+id, Token);
            var response = await http.PostBasicAsync("", HttpMethod.Get);
            return response;
        }
        public async Task<string> Update(int id, UpdateArticleDto model, string Token)
        {
            HttpRequest<string> http = new HttpRequest<string>(_UrlApi.URI, "Todo/" + id, Token);
            var response = await http.PostBasicAsync(model, HttpMethod.Put);
            return response;
        }
        public async Task<string> Delete(int id, string Token)
        {
            HttpRequest<string> http = new HttpRequest<string>(_UrlApi.URI, "Todo/" + id, Token);
            var response = await http.PostBasicAsync("", HttpMethod.Delete);
            return response;
        }

        public async Task<string> Create(CreateArticleRequest model, string Token)
        {
            HttpRequest<string> http = new HttpRequest<string>(_UrlApi.URI, "Todo", Token);
            var response = await http.PostBasicAsync(model, HttpMethod.Post);
            return response;
        }

    }
}
