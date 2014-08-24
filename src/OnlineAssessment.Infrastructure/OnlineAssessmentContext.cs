// Author:
//      Lu Rongkai <lurongkai@gmail.com>
// 
// Copyright (c) 2014 lurongkai
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
// 
// Source code hosted on: https://github.com/lurongkai/online-assessment

using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure.Mapping;

namespace OnlineAssessment.Infrastructure
{
    public class OnlineAssessmentContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineAssessmentContext() : base("DefaultConnection") {}

        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<ExaminationPaper> ExaminationPapers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<AnswerSheet> AnswerSheets { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
#if DEBUG
            Database.SetInitializer(new DropCreateDatabaseAlways<OnlineAssessmentContext>());
            Database.SetInitializer(new OnlineAssessmentContextInitializer());
#endif

            modelBuilder.Configurations
                        .Add(new ExaminationMapping())
                        .Add(new ExaminationPaperMapping())
                        .Add(new PaperQuestionMapping())
                        .Add(new PaperQuestionOptionMapping())
                        .Add(new QuestionMapping())
                        .Add(new QuestionOptionMapping())
                        .Add(new SubjectMapping())
                        .Add(new AnswerSheetMapping())
                        .Add(new StudentMapping())
                        .Add(new TeacherMapping())
                        .Add(new NewsMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}