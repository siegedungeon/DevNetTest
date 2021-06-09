using System.ComponentModel.DataAnnotations;

namespace WebApiBack.Models.DTOs.Request
{
    public class AproveArticleRequest
    {
        [Required]
        public long ArticleId { get; set; }
        [Required]
        public string AuthorId { get; set; }
    }
}
