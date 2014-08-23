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
using System.ComponentModel.DataAnnotations;

namespace OnlineAssessment.Domain
{
    public class Question : ICanMigrate
    {
        private double _questionDegree;

        public Question() {
            QuestionId = Guid.NewGuid();
            QuestionOptions = new List<QuestionOption>();
        }

        public Guid QuestionId { get; set; }

        [UIHint("QuestionForm")]
        public QuestionForm QuestionForm { get; set; }

        public QuestionModule QuestionModule { get; set; }
        public int Score { get; set; }

        [Required(ErrorMessage = "题目不能为空")]
        [Display(Name = "题目")]
        public string QuestionBody { get; set; }

        [Display(Name = "参考答案")]
        public string ReferenceRightAnswer { get; set; }

        public string subjectKey { get; set; }
        public virtual Subject Subject { get; set; }

        [Required]
        [UIHint("QuestionDegree")]
        [Display(Name = "难度")]
        public double QuestionDegree {
            get { return _questionDegree; }
            set {
                if (value < 0 || value > 1.0) { throw new InvalidOperationException("invalid degree value. degree value should > 0 and < 1.0"); }
                _questionDegree = value;
            }
        }

        public ICollection<QuestionOption> QuestionOptions { get; set; }

        public PaperQuestion ConvertToPaperQuestion() {
            var q = new PaperQuestion()
            {
                Score = Score,
                Degree = QuestionDegree,
                QuestionForm = QuestionForm,
                QuestionBody = QuestionBody,
                ReferenceRightAnswer = ReferenceRightAnswer
            };

            foreach (var questionOption in QuestionOptions) { q.QuestionOptions.Add(questionOption.ConvertToPaperQuestionOption()); }

            return q;
        }
    }
}