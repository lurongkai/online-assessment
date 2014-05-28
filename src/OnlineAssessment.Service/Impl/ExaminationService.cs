using System;
using OnlineAssessment.Domain;
using OnlineAssessment.Service.Message;

namespace OnlineAssessment.Service
{
    public class ExaminationService : IExaminationService
    {
        public Guid GenerateRandomExaminationPaper(ExaminationPaperConfig config)
        {
            throw new NotImplementedException();
        }

        public Guid AddExamination(Guid examinationPaperId, ExaminationConfig examinationPaper)
        {
            throw new NotImplementedException();
        }

        public void ActiveExamination(Guid examinationId)
        {
            throw new NotImplementedException();
        }

        public void ArchiveExamination(Guid examinationId)
        {
            throw new NotImplementedException();
        }
    }
}