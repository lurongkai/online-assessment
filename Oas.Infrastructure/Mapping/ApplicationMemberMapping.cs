using System.Data.Entity.ModelConfiguration;
using Oas.Domain;

namespace Oas.Infrastructure.Mapping
{
    public class StudentMapping : EntityTypeConfiguration<Student>
    {
        public StudentMapping() {
            HasKey(m => m.MemberId);
            ToTable("Students");

            HasMany(m => m.SubscribeCourses);
        }
    }

    public class TeacherMapping : EntityTypeConfiguration<Teacher>
    {
        public TeacherMapping() {
            HasKey(m => m.MemberId);
            ToTable("Teachers");

            HasRequired(m => m.TeachCourse);
        }
    }
}