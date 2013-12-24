using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class Student : SystemUser
    {
        public Student() {
            AnswerSheets = new List<AnswerSheet>();
        }

        public string StudentId { get; set; }

        public string JobTitle { get; set; }
        public string Company { get; set; }
        public CourseLevel StudingCourseLevel { get; set; }

        public virtual SystemUser Membership { get; set; }
        public virtual ICollection<AnswerSheet> AnswerSheets { get; set; }
    }
}
