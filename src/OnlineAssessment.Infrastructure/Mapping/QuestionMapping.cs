using System.Data.Entity.ModelConfiguration;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Infrastructure.Mapping
{
    public class QuestionMapping : EntityTypeConfiguration<Question>
    {
        public QuestionMapping() {
            HasKey(m => m.QuestionId);
            HasMany(m => m.QuestionOptions).WithRequired().WillCascadeOnDelete(true);

            Property(m => m.QuestionForm).IsRequired();
            Property(m => m.QuestionBody).IsRequired();
            Property(m => m.ReferenceRightAnswer).IsOptional();
            Property(m => m.QuestionDegree).IsRequired();

            HasRequired(m => m.Subject).WithMany().HasForeignKey(m => m.SubjectId);
        }
    }

    public class QuestionOptionMapping : EntityTypeConfiguration<QuestionOption>
    {
        public QuestionOptionMapping() {
            HasKey(m => m.QuestionOptionId);

            Property(m => m.Description).IsRequired();
            Property(m => m.IsRightAnswer).IsRequired();
        }
    }
}