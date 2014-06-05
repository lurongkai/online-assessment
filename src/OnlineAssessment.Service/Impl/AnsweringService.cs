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