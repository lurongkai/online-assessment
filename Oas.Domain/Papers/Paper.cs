using System;
using System.Collections.Generic;

namespace Oas.Domain
{
    public class Paper
    {
        public Paper() {
            SelectableQuestions = new List<SelectableQuestion>();
            SubjectiveQuestions = new List<SubjectiveQuestion>();
        }

        public ICollection<SelectableQuestion> SelectableQuestions { get; set; }
        public ICollection<SubjectiveQuestion> SubjectiveQuestions { get; set; }
    }
}