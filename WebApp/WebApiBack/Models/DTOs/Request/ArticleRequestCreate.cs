using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiBack.Models.DTOs.Request
{
    public class ArticleRequestCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Abstract { get; set; }
        [Required]
        public string Contents { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public string AuthorId { get; set; }
    }
}
