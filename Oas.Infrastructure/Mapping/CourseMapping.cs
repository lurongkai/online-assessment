using System.Data.Entity.ModelConfiguration;
using Oas.Domain;

namespace Oas.Infrastructure.Mapping
{
    public class CourseMapping : EntityTypeConfiguration<Course>
    {
        public CourseMapping() {
            HasKey(m => m.CourseId);

            Property(m => m.CourseName).IsRequired();
        }
    }
}