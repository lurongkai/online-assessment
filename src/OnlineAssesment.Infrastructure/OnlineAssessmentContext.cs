using Microsoft.AspNet.Identity.EntityFramework;
using OnlineAssesment.Domain;
using OnlineAssesment.Infrastructure.Mapping;
using System.Data.Entity;

namespace OnlineAssesment.Infrastructure
{
    public class OnlineAssessmentContext : IdentityDbContext<SystemUser>
    {
        public OnlineAssessmentContext(): base("DefaultConnection")
        {
        }

        public virtual DbSet<Examination> Examinations { get; set; }
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
                .Add(new ExaminationMapping())
                .Add(new ExaminationQuestionMapping())
                .Add(new ExaminationQuestionOptionMapping())
                .Add(new QuestionMapping())
                .Add(new QuestionOptionMapping())
                .Add(new SubjectMapping())
                .Add(new AnswerSheetMapping())
                .Add(new StudentMapping())
                .Add(new TeacherMapping());
        }
    }
}
