using Microsoft.AspNet.Identity.EntityFramework;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure.Mapping;
using System.Data.Entity;

namespace OnlineAssessment.Infrastructure
{
    public class OnlineAssessmentContext : IdentityDbContext<SystemUser>
    {
        public OnlineAssessmentContext(): base("DefaultConnection")
        {
        }

        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<ExaminationPaper> Examinations { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<AnswerSheet> AnswerSheets { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
#if DEBUG
            Database.SetInitializer(new DropCreateDatabaseAlways<OnlineAssessmentContext>());
#endif
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer(new OnlineAssessmentContextInitializer());

            modelBuilder.Configurations
                .Add(new ExaminationPaperMapping())
                .Add(new PaperQuestionMapping())
                .Add(new PaperQuestionOptionMapping())
                .Add(new QuestionMapping())
                .Add(new QuestionOptionMapping())
                .Add(new SubjectMapping())
                .Add(new AnswerSheetMapping())
                .Add(new StudentMapping())
                .Add(new TeacherMapping());
        }
    }
}
