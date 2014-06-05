using System.Data.Entity.ModelConfiguration;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Infrastructure.Mapping
{
    public class SubjectMapping : EntityTypeConfiguration<Subject>
    {
        public SubjectMapping() {
            HasKey(m => m.SubjectKey);

            Property(m => m.Name).IsRequired();
            Property(m => m.Description).IsOptional();

            HasRequired(m => m.ResponsibleTeacher).WithRequiredDependent().WillCascadeOnDelete(true);

            HasMany(m => m.SubscribedStudents);
            HasMany(m => m.Examinations);
        }
    }
}