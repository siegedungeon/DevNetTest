using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Request.Articles
{
    public class CreateArticleRequest
    {

            public string Title { get; set; }

            public string Abstract { get; set; }
            public string Contents { get; set; }
            public DateTime CreatedDate { get; set; }
            public string AuthorId { get; set; }
    }
}
