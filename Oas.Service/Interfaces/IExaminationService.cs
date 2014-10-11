using System;
using System.Collections.Generic;
using OnlineAssessment.Service.Message;

namespace Oas.Service.Interfaces
{
    public interface IExaminationService
    {
        Guid GenerateRandomExaminationPaper(ExaminationPaperConfig config);
        Guid AddExamination(string subjectKey, Guid examinationPaperId, ExaminationConfig examinationPaper);

        IEnumerable<ExaminationPaper> GetAllExaminationPapers(string subjectKey);
        ExaminationPaper GetExaminationPaper(Guid paperId);

        void ActiveExamination(Guid examinationId);
        void ArchiveExamination(Guid examinationId);

        Examination GetExamination(Guid examinationId);
        IEnumerable<Examination> GetAllExaminations(string subjectKey, ExaminationState? examinationState);
        IEnumerable<Examination> GetStudentAvailableExaminations(string userId, string subjectKey);

        void DeleteExaminationPaper(Guid paperId);
    }
}