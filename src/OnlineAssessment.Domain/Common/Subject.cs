using System;
using System.Collections.Generic;

namespace OnlineAssessment.Domain
{
    public class Subject : ICanMigrate
    {
        public Subject() {
            SubjectId = Guid.NewGuid();
        }

        public Guid SubjectId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> SubscribedStudents { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Examination> Examinations { get; set; }
        public virtual Teacher ResponsibleTeacher { get; set; }
    }
}