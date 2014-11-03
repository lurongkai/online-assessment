using System;
using System.Collections.Generic;

namespace Oas.Domain.Service
{
    public class Paper
    {
        public Paper() {
            SingleQuestions = new List<SelectableQuestion>();
            MultipleQuestions = new List<SelectableQuestion>();
            SubjectiveQuestions = new List<SubjectiveQuestion>();
        }

        public List<SelectableQuestion> SingleQuestions { get; set; }
        public List<SelectableQuestion> MultipleQuestions { get; set; }
        public List<SubjectiveQuestion> SubjectiveQuestions { get; set; }
    }
}