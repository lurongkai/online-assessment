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
        int GenerateRandomExamination(RandomExaminationConfig config);
        int AddExamination(Examination examination);
        void ActiveExamination(int examinationId);
        void ArchiveExamination(int examinationId);
    }
}
