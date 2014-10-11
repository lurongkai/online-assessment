using System;
using System.Collections.Generic;

namespace Oas.Service.Interfaces
{
    public interface IAnsweringService
    {
        Guid UploadAnswerSheet(Guid examinationId, string studentId, AnswerSheet answerSheet);

        IEnumerable<AnswerSheetItem> GetAllUnevaluatedAnswers(Guid examinationId);
        void EvaluatingAnswer(Guid answerSheetId, Guid answerId, int score);

        AnswerSheet GetAnswerSheet(Guid answerSheetId);
    }
}