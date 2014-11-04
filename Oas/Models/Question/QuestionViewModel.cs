using System.Collections.Generic;

namespace Oas.Models.Question
{
    public class QuestionViewModel
    {
        public QuestionViewModel(IEnumerable<Domain.Question> selectableQuestions, IEnumerable<Domain.Question> subjectiveQuestions) {
            this.SelectableQuestions = selectableQuestions;
            this.SubjectiveQuestions = subjectiveQuestions;
        }

        public IEnumerable<Domain.Question> SelectableQuestions { get; private set; }
        public IEnumerable<Domain.Question> SubjectiveQuestions { get; private set; }
    }
}