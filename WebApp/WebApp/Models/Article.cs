using System;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.User;

namespace WebApp.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Abstract { get; set; }
        [Required]
        public string Contents { get; set; }
        public DateTime CreatedDate { get; set; }

        public string AuthorId { get; set; }
        public virtual AppUser Author { get; set; }
    }
}
