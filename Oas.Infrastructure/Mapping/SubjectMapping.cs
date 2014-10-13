using System.Data.Entity.ModelConfiguration;
using Oas.Domain;

namespace Oas.Infrastructure.Mapping
{
    public class SubjectMapping : EntityTypeConfiguration<Subject>
    {
        public SubjectMapping() {
            HasKey(m => m.Name);
        }
    }
}