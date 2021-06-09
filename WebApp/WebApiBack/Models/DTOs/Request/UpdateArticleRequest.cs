using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiBack.Models.DTOs.Request
{
    public class UpdateArticleRequest
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
