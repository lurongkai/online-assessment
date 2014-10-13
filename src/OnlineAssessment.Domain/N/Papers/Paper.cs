using System;
using System.Collections.Generic;

namespace OnlineAssessment.Domain.N
{
    public class Paper
    {
        public Paper() {
            SelectableQuestions = new List<SelectableQuestion>();
            SubjectiveQuestions = new List<SubjectiveQuestion>();
        }

        public Guid PaperId { get; set; }

        public ICollection<SelectableQuestion> SelectableQuestions { get; set; }
        public ICollection<SubjectiveQuestion> SubjectiveQuestions { get; set; }
    }
}