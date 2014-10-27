using System.Data.Entity.ModelConfiguration;
using Oas.Domain.Application;

namespace Oas.Infrastructure.Mapping
{
    public class NewsMapping : EntityTypeConfiguration<News>
    {
        public NewsMapping() {
            HasKey(m => m.NewsId);

            Property(m => m.Title).IsRequired();
            Property(m => m.Content).IsRequired();
        }
    }
}