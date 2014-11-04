using System;

namespace Oas.Domain.Application
{
    public class News
    {
        public News() {
            NewsId = Guid.NewGuid();
        }

        public Guid NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}