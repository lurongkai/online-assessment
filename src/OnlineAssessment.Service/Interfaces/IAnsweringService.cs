using OnlineAssessment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Service
{
    public interface IAnsweringService
    {
        Guid UploadAnswerSheet(Guid examinationId, AnswerSheet answerSheet);

        IList<AnswerSheetItem> GetAllUnevaluatedAnswers(Guid examinationId);
        void EvaluatingAnswer(Guid answerId, int score);
    }
}
