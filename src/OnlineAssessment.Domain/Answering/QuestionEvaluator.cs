// Author:
//      Lu Rongkai <lurongkai@gmail.com>
// 
// Copyright (c) 2014 lurongkai
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
// 
// Source code hosted on: https://github.com/lurongkai/online-assessment

using System;
using System.Linq;

namespace OnlineAssessment.Domain
{
    internal class QuestionEvaluator
    {
        internal void Evaluate(AnswerSheetItem answerSheetItem) {
            var questionForm = answerSheetItem.PaperQuestion.QuestionForm;
            if (questionForm == QuestionForm.SingleSelection) { EvaluateSingleSelection(answerSheetItem); }

            if (questionForm == QuestionForm.MultipleSelection) { EvaluateMultipleSelection(answerSheetItem); }
        }

        private void EvaluateSingleSelection(AnswerSheetItem answerSheetItem) {
            if (answerSheetItem.Choices.Count > 1) { throw new InvalidOperationException("single selection can only choice one answer."); }

            var answer = answerSheetItem.Choices.FirstOrDefault();

            if (answer != null && answer.IsRightAnswer) { answerSheetItem.ObtainedScore = answerSheetItem.PaperQuestion.Score; }
            else { answerSheetItem.ObtainedScore = 0; }
        }

        private void EvaluateMultipleSelection(AnswerSheetItem answerSheetItem) {
            if (answerSheetItem.Choices.Count == 0) { answerSheetItem.ObtainedScore = 0; }
            ;

            if (answerSheetItem.Choices.Any(c => !c.IsRightAnswer)) {
                answerSheetItem.ObtainedScore = 0;
                return;
            }

            var rightAnswerCount = answerSheetItem.Choices.Count(c => c.IsRightAnswer);
            var allRightAnswerCount = answerSheetItem.GetRightAnswerCount();

            if (rightAnswerCount == allRightAnswerCount) { answerSheetItem.ObtainedScore = answerSheetItem.PaperQuestion.Score; }
            else { answerSheetItem.ObtainedScore = answerSheetItem.PaperQuestion.Score/2; }
        }
    }
}