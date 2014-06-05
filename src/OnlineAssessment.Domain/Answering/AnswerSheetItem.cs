using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessment.Domain
{
    public class AnswerSheetItem
    {
        public AnswerSheetItem() {
            AnswerSheetItemId = Guid.NewGuid();
            Choices = new List<PaperQuestionOption>();
        }

        public Guid AnswerSheetItemId { get; set; }

        public string Answer { get; set; }
        public virtual ICollection<PaperQuestionOption> Choices { get; set; }

        public virtual PaperQuestion PaperQuestion { get; set; }
        public int? ObtainedScore { get; set; }

        internal void Evaluate() {
            var evaluator = new QuestionEvaluator();
            evaluator.Evaluate(this);
        }

        internal int GetRightAnswerCount() {
            return PaperQuestion.QuestionOptions.Count(q => q.IsRightAnswer);
        }
    }
}