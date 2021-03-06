﻿using System.Data.Entity;
using Oas.Domain;
using Oas.Domain.Application;
using Oas.Infrastructure.Mapping;

namespace Oas.Infrastructure
{
    public class OasContext : DbContext
    {
        public OasContext() : base("Oas.Application")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<SelectableQuestion> SelectableQuestions { get; set; }
        public virtual DbSet<SubjectiveQuestion> SubjectiveQuestions { get; set; }

        public virtual DbSet<AnswerSheet> AnswerSheets { get; set; }

        public virtual DbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
#if DEBUG
            Database.SetInitializer(new DropCreateDatabaseAlways<OasContext>());
            Database.SetInitializer(new OasContextInitializer());
#endif

            modelBuilder.Configurations
                .Add(new CourseMapping())
                .Add(new SubjectMapping())
                .Add(new SelectableQuestionMapping())
                .Add(new SubjectiveQuestionMapping())
                .Add(new QuestionOptionMapping())
                .Add(new StudentMapping())
                .Add(new TeacherMapping())
                .Add(new NewsMapping())
                .Add(new AnswerSheetMapping())
                .Add(new SelectableQuestionItemMapping())
                .Add(new QuestionItemOptionMapping())
                .Add(new SubjectiveQuestionItemMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}