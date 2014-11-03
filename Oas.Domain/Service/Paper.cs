using System;
using System.Collections.Generic;

namespace Oas.Domain.Service
{
    public class Paper
    {
        public Paper() {
            SelectableQuestions = new List<SelectableQuestion>();
            SubjectiveQuestions = new List<SubjectiveQuestion>();
        }

        public List<SelectableQuestion> SelectableQuestions { get; set; }
        public List<SubjectiveQuestion> SubjectiveQuestions { get; set; }
    }
}