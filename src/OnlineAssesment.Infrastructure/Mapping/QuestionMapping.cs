using OnlineAssesment.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Infrastructure.Mapping
{
    public class QuestionMapping : EntityTypeConfiguration<Question>
    {
        public QuestionMapping() {
            HasKey(m => m.QuestionId);
            Property(m => m.QuestionBody).IsRequired();
            HasMany(m => m.QuestionOptions).WithRequired().WillCascadeOnDelete(true);
        }
    }
}
