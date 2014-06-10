using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Infrastructure.Mapping
{
    public class NewsMapping : EntityTypeConfiguration<News>
    {
        public NewsMapping()
        {
            HasKey(m => m.NewsId);

            Property(m => m.Title).IsRequired();
            Property(m => m.Content).IsRequired();
        }
    }
}
