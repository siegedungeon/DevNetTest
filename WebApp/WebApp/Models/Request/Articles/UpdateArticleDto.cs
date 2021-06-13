using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Request.Articles
{
    public class UpdateArticleDto
    {
       
            [Required]
            public long ArticleId { get; set; }
            [Required]
            public string Title { get; set; }
            [Required]
            public string Abstract { get; set; }
            [Required]
            public string Contents { get; set; }
            public DateTime CreatedDate { get; set; }

    }
}
