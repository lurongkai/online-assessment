using System;
using System.Collections;
using System.Collections.Generic;
using Oas.Domain;
using Oas.Domain.Service;
using Oas.Service.Messages;

namespace Oas.Service.Interfaces
{
    public interface IExamService
    {
        Paper GeneratePaper(string courseId, string style);
        Guid UploadAnswerSheet(string courseId, Guid studentId, AnswerSheet answerSheet);
        void PreEvaluation(Guid answerSheetId);
        IEnumerable<AnswerSheet> GetStudentAnswerSheets(Guid studentId);
        IEnumerable<AnswerSheet> GetUnevaluatedAnswerSheets(string courseId);
        void EvaluateAnswerSheet(Guid answerSheetId, AnswerSheetEnvaluation evaluation);
        AnswerSheet GetAnswerSheet(Guid answerSheetId);
    }
}