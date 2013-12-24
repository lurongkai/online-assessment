using OnlineAssesment.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Infrastructure.Mapping
{
    public class StudentMapping : EntityTypeConfiguration<Student>
    {
        public StudentMapping() {
            HasKey(m => m.StudentId);
            Property(m => m.StudentId).HasColumnName("StudentId");
            HasRequired(m => m.Membership).WithOptional().Map(m => m.MapKey("StudentId"));
            HasMany(m => m.AnswerSheets);

            Property(m => m.Name).IsRequired();
            Property(m => m.Phone).IsOptional();
            Property(m => m.Email).IsOptional();
            Property(m => m.Gender).IsRequired();

            Property(m => m.JobTitle).IsOptional();
            Property(m => m.Company).IsOptional();
            Property(m => m.StudingCourseLevel).IsRequired();
        }
    }

    //public class TeacherMapping : EntityTypeConfiguration<Teacher>
    //{
    //    public TeacherMapping() {
    //        HasKey(m => new { m.TeacherId, m.MemberId });

    //        Property(m => m.Name).IsRequired();
    //        Property(m => m.Phone).IsOptional();
    //        Property(m => m.Email).IsOptional();
    //        Property(m => m.Gender).IsRequired();
    //    }
    //}
}
