using OnlineAssesment.Domain;
using OnlineAssesment.Infrastructure.Mapping;
using System.Data.Entity;

namespace OnlineAssesment.Infrastructure
{
    public class OnlineAssessmentContext : DbContext
    {
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerSheet> AnswerSheets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer(new OnlineAssessmentContextInitializer());

            modelBuilder.Configurations
                .Add(new ExaminationMapping())
                .Add(new ExaminationQuestionMapping())
                .Add(new ExaminationQuestionOptionMapping())
                .Add(new QuestionMapping())
                .Add(new QuestionOptionMapping())
                .Add(new ChapterMapping())
                .Add(new AnswerSheetMapping());
        }
    }
}
