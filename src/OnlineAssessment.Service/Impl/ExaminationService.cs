using System;
using System.Data.Entity;
using System.Linq;
using OnlineAssessment.Domain;
using OnlineAssessment.Domain.Service.ExaminationGeneration;
using OnlineAssessment.Infrastructure;
using OnlineAssessment.Service.Message;

namespace OnlineAssessment.Service
{
    public class ExaminationService : IExaminationService
    {
        public Guid GenerateRandomExaminationPaper(ExaminationPaperConfig config)
        {
            using (var context = new OnlineAssessmentContext())
            {
                var questions = context
                    .Questions
                    .Where(q => q.Subject.SubjectId == config.SubjectId)
                    .Include("QuestionOptions");
                var generator = new RandomExaminationGenerationService(questions);

                var paper = generator.GenerateExaminationPaper(config.AsPaperConstraint());
                context.ExaminationPapers.Add(paper);
                context.SaveChanges();

                return paper.ExaminationPaperId;
            }
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

        public Examination GetExamination(Guid examinationId) {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.ICollection<Examination> GetAvailableExaminations(string userId) {
            throw new NotImplementedException();
        }
    }
}