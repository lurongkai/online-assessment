using System;
using System.Collections.Generic;

namespace OnlineAssessment.Domain
{
    public class Subject : ICanMigrate
    {
        public string SubjectKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Teacher ResponsibleTeacher { get; set; }
        public virtual ICollection<Student> SubscribedStudents { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Examination> Examinations { get; set; }
    }
}