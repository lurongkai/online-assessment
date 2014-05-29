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

        void ActiveExamination(Guid examinationId);
        void ArchiveExamination(Guid examinationId);

        Examination GetExamination(Guid examinationId);
        IEnumerable<Examination> GetStudentAvailableExaminations(string userId, Guid subjectId);
    }
}