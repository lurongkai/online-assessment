using System.Data.Entity.ModelConfiguration;
using OnlineAssesment.Domain;

namespace OnlineAssesment.Infrastructure.Mapping
{
    public class SubjectMapping : EntityTypeConfiguration<Subject>
    {
        public SubjectMapping() {
            HasKey(m => m.SubjectId);

            Property(m => m.Name).IsRequired();
        }
    }
}