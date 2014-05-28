using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var examination = context.Examinations.Find(examinationId);
                examination.AnswerSheets.Add(answerSheet);
                context.SaveChanges();

                return answerSheet.AnswerSheetId;
            }
        }

        public IList<AnswerSheetItem> GetAllUnevaluatedAnswers(Guid examinationId)
        {
            using (var context = new OnlineAssessmentContext()) {
                var examination = context.Examinations.Find(examinationId);
                var unevaluatedAnswers = examination.AnswerSheets.SelectMany(a => a.AnswerItems)
                    .Where(ai => ai.ObtainedScore == null);

                return unevaluatedAnswers.ToList();
            }
        }

        public void EvaluatingAnswer(Guid answerSheetId, Guid answerId, int score)
        {
            using (var context = new OnlineAssessmentContext())
            {
                var answerSheet = context.AnswerSheets.Find(answerSheetId);
                var answer = answerSheet.AnswerItems.First(ai => ai.AnswerSheetItemId == answerId);
                answer.ObtainedScore = score;

                context.SaveChanges();
            }
        }
    }
}
