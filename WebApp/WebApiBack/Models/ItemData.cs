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
        public AppUserBack UserAprove { get; set; }
        public virtual AppUserBack Author { get; set; }
       
    }
}