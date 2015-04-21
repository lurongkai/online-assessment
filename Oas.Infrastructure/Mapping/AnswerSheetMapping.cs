using System.Data.Entity.ModelConfiguration;
using Oas.Domain;

namespace Oas.Infrastructure.Mapping
{
    public class AnswerSheetMapping : EntityTypeConfiguration<AnswerSheet>
    {
        public AnswerSheetMapping()
        {
            HasKey(m => m.AnswerSheetId);

            HasRequired(m => m.Course);
            HasRequired(m => m.Student);
        }
    }

    public class SelectableQuestionItemMapping : EntityTypeConfiguration<SelectableQuestionItem>
    {
        public SelectableQuestionItemMapping()
        {
            HasKey(m => m.SelectableQuestionItemId);

            HasRequired(m => m.Question).WithMany().HasForeignKey(m => m.QuestionId);
        }
    }

    public class QuestionItemOptionMapping : EntityTypeConfiguration<QuestionItemOption>
    {
        public QuestionItemOptionMapping()
        {
            HasKey(m => m.QuestionItemOptionId);
        }
    }

    public class SubjectiveQuestionItemMapping : EntityTypeConfiguration<SubjectiveQuestionItem>
    {
        public SubjectiveQuestionItemMapping()
        {
            HasKey(m => m.SubjectiveQuestionItemId);
            HasRequired(m => m.Question).WithMany().HasForeignKey(m => m.QuestionId);
        }
    }
}