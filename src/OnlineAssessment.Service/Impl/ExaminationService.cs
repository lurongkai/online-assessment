using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Service
{
    public class ExaminationService : IExaminationService
    {
        public int GenerateRandomExamination(Message.RandomExaminationConfig config) {
            throw new NotImplementedException();
        }

        public int AddExamination(Domain.Examination examination) {
            throw new NotImplementedException();
        }

        public void ActiveExamination(int examinationId) {
            throw new NotImplementedException();
        }

        public void ArchiveExamination(int examinationId) {
            throw new NotImplementedException();
        }
    }
}
