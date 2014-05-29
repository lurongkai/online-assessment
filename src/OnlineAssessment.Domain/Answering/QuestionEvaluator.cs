using System;
using System.Linq;

namespace OnlineAssessment.Domain
{
    internal class QuestionEvaluator
    {
        internal void Evaluate(AnswerSheetItem answerSheetItem) {
            var questionForm = answerSheetItem.PaperQuestion.QuestionForm;
            if (questionForm == QuestionForm.SingleSelection) {
                EvaluateSingleSelection(answerSheetItem);
            }

            if (questionForm == QuestionForm.MultipleSelection) {
                EvaluateMultipleSelection(answerSheetItem);
            }
        }

        private void EvaluateSingleSelection(AnswerSheetItem answerSheetItem) {
            if (answerSheetItem.Choices.Count > 1) {
                throw new InvalidOperationException("single selection can only choice one answer.");
            }

            var answer = answerSheetItem.Choices.FirstOrDefault();

            if (answer != null && answer.IsRightAnswer) {
                answerSheetItem.ObtainedScore = answerSheetItem.PaperQuestion.Score;
            } else {
                answerSheetItem.ObtainedScore = 0;
            }
        }

        private void EvaluateMultipleSelection(AnswerSheetItem answerSheetItem) {
            if (answerSheetItem.Choices.Count == 0) {
                answerSheetItem.ObtainedScore = 0;
            }
            ;

            if (answerSheetItem.Choices.Any(c => !c.IsRightAnswer)) {
                answerSheetItem.ObtainedScore = 0;
                return;
            }

            var rightAnswerCount = answerSheetItem.Choices.Count(c => c.IsRightAnswer);
            var allRightAnswerCount = answerSheetItem.GetRightAnswerCount();

            if (rightAnswerCount == allRightAnswerCount) {
                answerSheetItem.ObtainedScore = answerSheetItem.PaperQuestion.Score;
            } else {
                answerSheetItem.ObtainedScore = answerSheetItem.PaperQuestion.Score/2;
            }
        }
    }
}