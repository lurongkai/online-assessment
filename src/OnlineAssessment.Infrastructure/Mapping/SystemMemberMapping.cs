using OnlineAssessment.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Infrastructure.Mapping
{
    public class StudentMapping : EntityTypeConfiguration<Student>
    {
        public StudentMapping() {
            HasMany(m => m.AnswerSheets);
            ToTable("Students");

            Property(m => m.JobTitle).IsOptional();
            Property(m => m.Company).IsOptional();

            HasMany(m => m.LearningSubjects).WithMany(m => m.SubscribedStudents);
        }
    }

    public class TeacherMapping : EntityTypeConfiguration<Teacher>
    {
        public TeacherMapping() {
            ToTable("Teachers");
            HasRequired(m => m.ResponsibleSubject).WithOptional(m => m.ResponsibleTeacher);
        }
    }
}
