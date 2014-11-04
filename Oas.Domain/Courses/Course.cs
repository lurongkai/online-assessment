using System.Collections.Generic;
using System.Linq;

namespace Oas.Domain
{
    public class Course : IAggregateRoot<Course>
    {
        public Course() {
            PinSubjects = new List<SubjectPin>();
        }

        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public virtual List<SubjectPin> PinSubjects { get; set; }

        //protected override IEnumerable<object> GetAtomicValues() {
        //    yield return CourseId;
        //    yield return CourseName;
        //    yield return Description;
        //}

        public void Pin(Subject subject, string pinName) {
            if (PinSubjects.All(p => p.SubjectId != subject.SubjectId)) {
                PinSubjects.Add(new SubjectPin {SubjectId = subject.SubjectId, PinName = pinName});
            }
        }

        public void UnPin(Subject subject) {
            var pin = PinSubjects.SingleOrDefault(p => p.SubjectId == subject.SubjectId);
            if (pin != null) {
                PinSubjects.Remove(pin);
            }
        }
    }
}