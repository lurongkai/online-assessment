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
using System.Collections.Generic;
using OnlineAssessment.Domain;
using OnlineAssessment.Domain.Service.PaperGeneration;

namespace OnlineAssessment.Service.Message
{
    public class ExaminationPaperConfig
    {
        public string SubjectKey { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public double Degree { get; set; }
        public int TotalScore { get; set; }

        public int SingleSelectionQuestionQuantity { get; set; }
        public int MutipleSelectionQuestionQuantity { get; set; }
        public int SubjectiveQuestionQuantity { get; set; }

        public ExaminationType ExaminationType { get; set; }

        internal PaperConstraint AsPaperConstraint() {
            var questionQuota = GetQuestionQuota();
            return new PaperConstraint(TotalScore, Degree, questionQuota);
        }

        private IDictionary<QuestionForm, int> GetQuestionQuota() {
            var quota = new Dictionary<QuestionForm, int>();

            quota.Add(QuestionForm.SingleSelection, SingleSelectionQuestionQuantity);
            quota.Add(QuestionForm.MultipleSelection, MutipleSelectionQuestionQuantity);
            quota.Add(QuestionForm.Subjective, SubjectiveQuestionQuantity);

            return quota;
        }
    }

    public class ExaminationConfig
    {
        public string Title { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }

        public bool BeginImmediately { get; set; }
    }
}