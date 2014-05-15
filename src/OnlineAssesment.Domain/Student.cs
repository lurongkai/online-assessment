using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class Student : SystemUser
    {
        public Student()
        {
            LearningSubjects = new List<Subject>();
            AnswerSheets = new List<AnswerSheet>();
        }

        public string JobTitle { get; set; }
        public string Company { get; set; }

        public virtual ICollection<Subject> LearningSubjects { get; set; }
        // TODO: ??
        public virtual ICollection<AnswerSheet> AnswerSheets { get; set; }
    }
}
