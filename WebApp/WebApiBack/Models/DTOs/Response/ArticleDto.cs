using System;

namespace WebApiBack.Models.DTOs.Response
{
    public class ArticleDto
    {
        public long ArticleId { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Contents { get; set; }
        public DateTime CreatedDate { get; set; }

        public string AuthorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int HasAproval { get; set; }

    }
}
