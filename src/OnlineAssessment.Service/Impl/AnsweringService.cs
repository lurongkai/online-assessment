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
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;

namespace OnlineAssessment.Service
{
    public class AnsweringService : IAnsweringService
    {
        public Guid UploadAnswerSheet(Guid examinationId, string studentId, AnswerSheet answerSheet) {
            using (var context = new OnlineAssessmentContext()) {
                var examination = context.Examinations.Find(examinationId);
                var student = context.Students.Find(studentId);

                answerSheet.Student = student;

                examination.AnswerSheets.Add(answerSheet);
                context.SaveChanges();

                return answerSheet.AnswerSheetId;
            }
        }

        public IEnumerable<AnswerSheetItem> GetAllUnevaluatedAnswers(Guid examinationId) {
            using (var context = new OnlineAssessmentContext()) {
                var examination = context.Examinations.Find(examinationId);
                var unevaluatedAnswers = examination.AnswerSheets.SelectMany(a => a.AnswerItems)
                                                    .Where(ai => ai.ObtainedScore == null);

                return unevaluatedAnswers;
            }
        }

        public void EvaluatingAnswer(Guid answerSheetId, Guid answerId, int score) {
            using (var context = new OnlineAssessmentContext()) {
                var answerSheet = context.AnswerSheets.Find(answerSheetId);
                var answer = answerSheet.AnswerItems.First(ai => ai.AnswerSheetItemId == answerId);
                answer.ObtainedScore = score;

                context.SaveChanges();
            }
        }

        public AnswerSheet GetAnswerSheet(Guid answerSheetId) {
            using (var context = new OnlineAssessmentContext()) {
                var answerSheet = context.AnswerSheets.Find(answerSheetId);
                return answerSheet;
            }
        }
    }
}