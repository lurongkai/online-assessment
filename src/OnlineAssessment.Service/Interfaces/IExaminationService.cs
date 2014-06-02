using System;
using System.Collections.Generic;
using OnlineAssessment.Domain;
using OnlineAssessment.Service.Message;

namespace OnlineAssessment.Service
{
    public interface IExaminationService
    {
        Guid GenerateRandomExaminationPaper(ExaminationPaperConfig config);
        Guid AddExamination(Guid examinationPaperId, ExaminationConfig examinationPaper);

        IEnumerable<ExaminationPaper> GetAllExaminationPapers(Guid subjectId);
        ExaminationPaper GetExaminationPaper(Guid paperId);

        void ActiveExamination(Guid examinationId);
        void ArchiveExamination(Guid examinationId);

        Examination GetExamination(Guid examinationId);
        IEnumerable<Examination> GetAllExaminations(Guid subjectId);
        IEnumerable<Examination> GetStudentAvailableExaminations(string userId, Guid subjectId);
    }
}