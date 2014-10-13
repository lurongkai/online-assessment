using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oas.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Oas.Infrastructure.Mapping
{
    public class CourseMapping : EntityTypeConfiguration<Course>
    {
        public CourseMapping() {
            HasKey(m => m.CourseKey);
        }
    }
}
