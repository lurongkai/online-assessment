using OnlineAssesment.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Infrastructure.Mapping
{
    public class AnswerSheetMapping : EntityTypeConfiguration<AnswerSheet>
    {
        public AnswerSheetMapping() {
            HasKey(m => m.AnswerSheetId);
            HasRequired(m => m.Student).WithMany();
            HasRequired(m => m.Examination);
            HasOptional(m => m.AnswerItems).WithRequired().WillCascadeOnDelete(true);

            Property(m => m.SubmitDate).IsRequired();
        }
    }

    public class AnswerSheetItemMapping : EntityTypeConfiguration<AnswerSheetItem>
    {
        public AnswerSheetItemMapping() {
            HasKey(m => m.AnswerSheetItemId);
            HasRequired(m => m.Question);

            Property(m => m.QuestionId).IsRequired();
            Property(m => m.Answer).IsOptional();
        }
    }
}
