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
using System.Data.Entity;
using System.Linq;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;

namespace OnlineAssessment.Service
{
    public class QuestionService : IQuestionService
    {
        public IEnumerable<Question> GetAllQuestion(string subjectKey, int? page, QuestionForm? questionType = null) {
            using (var context = new OnlineAssessmentContext()) {
                var courseQuestions = context
                    .Questions
                    .Where(q => q.Subject.SubjectKey == subjectKey)
                    .Where(q => questionType == null || q.QuestionForm == questionType)
                    .OrderByDescending(q => q.QuestionForm)
                    .Skip(50*(page ?? 1 - 1))
                    .Take(50)
                    .ToList();

                return courseQuestions;
            }
        }

        public Question GetQuestion(Guid questionId) {
            using (var context = new OnlineAssessmentContext()) {
                var question = context.Questions.Find(questionId);

                return question;
            }
        }

        public Guid AddQuestion(string subjectKey, Question question) {
            using (var context = new OnlineAssessmentContext()) {
                var subject = context.Subjects.Find(subjectKey);
                subject.Questions.Add(question);
                context.SaveChanges();

                return question.QuestionId;
            }
        }

        public void ModifyQuestion(Question question) {
            using (var context = new OnlineAssessmentContext()) {
                context.Questions.Attach(question);
                context.Entry(question).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteQuestion(Guid questionId) {
            using (var context = new OnlineAssessmentContext()) {
                var question = context.Questions.Find(questionId);
                context.Questions.Remove(question);
                context.SaveChanges();
            }
        }
    }
}