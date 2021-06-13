using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiBack.Models.DTOs.Request
{
    public class ArticleRequestCreate
    {
 
        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Contents { get; set; }
        public DateTime CreatedDate { get; set; }

        public string AuthorId { get; set; }
    }
}
