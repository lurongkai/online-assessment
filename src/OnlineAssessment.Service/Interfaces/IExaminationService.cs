using OnlineAssessment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        ICollection<Examination> GetAvailableExaminations(string userId);
    }
}
