using System.Data.Entity.ModelConfiguration;
using Oas.Domain;

namespace Oas.Infrastructure.Mapping
{
    public class SelectableQuestionMapping : EntityTypeConfiguration<SelectableQuestion>
    {
        public SelectableQuestionMapping() {
            Map(m => m.MapInheritedProperties());
            ToTable("SelectableQuestions");

            HasKey(m => m.QuestionId);
            HasMany(m => m.Options).WithRequired().WillCascadeOnDelete(true);
        }
    }

    public class SubjectiveQuestionMapping : EntityTypeConfiguration<SubjectiveQuestion>
    {
        public SubjectiveQuestionMapping() {
            Map(m => m.MapInheritedProperties());
            ToTable("SubjectiveQuestions");

            HasKey(m => m.QuestionId);
            HasRequired(m => m.Answer);
        }
    }

    public class QuestionOptionMapping : EntityTypeConfiguration<Option>
    {
        public QuestionOptionMapping() {
            HasKey(m => m.OptionId);

            Property(m => m.Content).IsRequired();
            Property(m => m.IsRight).IsRequired();
        }
    }
}