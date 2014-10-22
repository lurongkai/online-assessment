using System.Collections;
using System.Collections.Generic;

namespace Oas.Domain
{
    public class Course : ValueObject
    {
        public Course() {
            PinSubjects = new List<SubjectPin>();
        }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public virtual List<SubjectPin> PinSubjects { get; set; }

        protected override IEnumerable<object> GetAtomicValues() {
            yield return CourseId;
            yield return CourseName;
            yield return Description;
        }
    }
}