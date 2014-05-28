using System;
using System.Collections.Generic;
using System.Linq;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;

namespace OnlineAssessment.Service
{
    public class AnsweringService : IAnsweringService
    {
        public Guid UploadAnswerSheet(Guid examinationId, AnswerSheet answerSheet)
        {
            using (var context = new OnlineAssessmentContext())
            {
                Examination examination = context.Examinations.Find(examinationId);
                examination.AnswerSheets.Add(answerSheet);
                context.SaveChanges();

                return answerSheet.AnswerSheetId;
            }
        }

        public IList<AnswerSheetItem> GetAllUnevaluatedAnswers(Guid examinationId)
        {
            using (var context = new OnlineAssessmentContext())
            {
                Examination examination = context.Examinations.Find(examinationId);
                IEnumerable<AnswerSheetItem> unevaluatedAnswers = examination.AnswerSheets.SelectMany(a => a.AnswerItems)
                    .Where(ai => ai.ObtainedScore == null);

                return unevaluatedAnswers.ToList();
            }
        }

        public void EvaluatingAnswer(Guid answerSheetId, Guid answerId, int score)
        {
            using (var context = new OnlineAssessmentContext())
            {
                AnswerSheet answerSheet = context.AnswerSheets.Find(answerSheetId);
                AnswerSheetItem answer = answerSheet.AnswerItems.First(ai => ai.AnswerSheetItemId == answerId);
                answer.ObtainedScore = score;

                context.SaveChanges();
            }
        }
    }
}