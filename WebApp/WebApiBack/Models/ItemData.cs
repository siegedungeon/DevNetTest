using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using WebApiBack.Models.DTOs;

namespace WebApiBack.Models
{
    public class Article
    {
        [Required]
        [Key]
        public long ArticleId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Abstract { get; set; }
        [Required]
        public string Contents { get; set; }
        public DateTime CreatedDate { get; set; }

        public int HasAproval { get; set; }
        public virtual IdentityUser UserAprove { get; set; }
        public virtual IdentityUser Author { get; set; }
        public string AuthorId { get; set; }
        public string UserAproveId { get; set; }

    }
}