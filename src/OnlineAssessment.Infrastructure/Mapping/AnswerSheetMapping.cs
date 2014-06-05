using System.Data.Entity.ModelConfiguration;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Infrastructure.Mapping
{
    public class AnswerSheetMapping : EntityTypeConfiguration<AnswerSheet>
    {
        public AnswerSheetMapping() {
            HasKey(m => m.AnswerSheetId);
            HasRequired(m => m.Student).WithMany(m => m.AnswerSheets);
            HasRequired(m => m.Examination);
            HasMany(m => m.AnswerItems).WithRequired().WillCascadeOnDelete(true);

            Property(m => m.SubmitDate).IsRequired();
            Ignore(m => m.HasFullGrade);
        }
    }

    public class AnswerSheetItemMapping : EntityTypeConfiguration<AnswerSheetItem>
    {
        public AnswerSheetItemMapping() {
            HasKey(m => m.AnswerSheetItemId);
            HasRequired(m => m.PaperQuestion);

            Property(m => m.Answer).IsOptional();

            HasMany(m => m.Choices);
        }
    }
}