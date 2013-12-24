using OnlineAssesment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Service
{
    public interface IAnsweringService
    {
        int UploadAnswerSheet(AnswerSheet answerSheet);

        IList<AnswerSheetItem> GetAllUnevaluatedAnswers(int examinationId);
        void EvaluatingAnswer(int answerId, int score);
    }
}
