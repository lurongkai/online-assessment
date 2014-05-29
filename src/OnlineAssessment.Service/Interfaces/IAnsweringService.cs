using System;
using System.Collections.Generic;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Service
{
    public interface IAnsweringService
    {
        Guid UploadAnswerSheet(Guid examinationId, string studentId, AnswerSheet answerSheet);

        IList<AnswerSheetItem> GetAllUnevaluatedAnswers(Guid examinationId);
        void EvaluatingAnswer(Guid answerSheetId, Guid answerId, int score);
    }
}