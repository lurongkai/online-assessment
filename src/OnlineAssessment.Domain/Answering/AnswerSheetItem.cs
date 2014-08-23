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