﻿using System.Collections.Generic;

namespace OnlineAssessment.Domain
{
    public class Student : ApplicationUser
    {
        public Student() {
            LearningSubjects = new List<Subject>();
            AnswerSheets = new List<AnswerSheet>();
        }

        public string JobTitle { get; set; }
        public string Company { get; set; }

        public virtual ICollection<Subject> LearningSubjects { get; set; }
        public virtual ICollection<AnswerSheet> AnswerSheets { get; set; }
    }
}