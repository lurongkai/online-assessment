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
    public class AnswerSheet
    {
        public AnswerSheet() {
            AnswerSheetId = Guid.NewGuid();
            AnswerItems = new List<AnswerSheetItem>();
        }

        public Guid AnswerSheetId { get; set; }

        public DateTime SubmitDate { get; set; }
        public virtual Student Student { get; set; }
        public virtual Examination Examination { get; set; }
        public ICollection<AnswerSheetItem> AnswerItems { get; set; }

        public bool HasFullGrade {
            get { return AnswerItems.All(ai => ai.ObtainedScore != null); }
        }

        public void Evaluate() {
            foreach (var answerSheetItem in AnswerItems) {
                if (answerSheetItem.ObtainedScore.HasValue) { continue; }

                answerSheetItem.Evaluate();
            }
        }
    }
}