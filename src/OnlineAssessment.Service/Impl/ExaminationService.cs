using System;
using System.Collections.Generic;
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
                IQueryable<Question> questions = context
                    .Questions
                    .Where(q => q.Subject.SubjectId == config.SubjectId)
                    .Include("QuestionOptions");
                var generator = new RandomExaminationGenerationService(questions);

                ExaminationPaper paper = generator.GenerateExaminationPaper(config.AsPaperConstraint());
                context.ExaminationPapers.Add(paper);
                context.SaveChanges();

                return paper.ExaminationPaperId;
            }
        }

        public Guid AddExamination(Guid examinationPaperId, ExaminationConfig examinationPaper)
        {
            using (var context = new OnlineAssessmentContext())
            {
                ExaminationPaper paper = context.ExaminationPapers.Find(examinationPaperId);
                var examination = new Examination();
                examination.BeginDate = examinationPaper.BeginDate;
                examination.DueDate = examinationPaper.EndDate;
                examination.Duration = examinationPaper.Duration.TotalMinutes;
                examination.Paper = paper;

                if (examinationPaper.BeginImmediately)
                {
                    examination.State = ExaminationState.Normal;
                }
                else
                {
                    examination.State = ExaminationState.Pending;
                }

                context.Examinations.Add(examination);
                context.SaveChanges();

                return examination.ExaminationId;
            }
        }

        public void ActiveExamination(Guid examinationId)
        {
            using (var context = new OnlineAssessmentContext())
            {
                Examination examination = context.Examinations.Find(examinationId);
                examination.State = ExaminationState.Normal;
                context.SaveChanges();
            }
        }

        public void ArchiveExamination(Guid examinationId)
        {
            using (var context = new OnlineAssessmentContext())
            {
                Examination examination = context.Examinations.Find(examinationId);
                examination.State = ExaminationState.Archived;
                context.SaveChanges();
            }
        }

        public Examination GetExamination(Guid examinationId)
        {
            using (var context = new OnlineAssessmentContext())
            {
                Examination examination = context.Examinations.Find(examinationId);
                return examination;
            }
        }

        public ICollection<Examination> GetAvailableExaminations(string userId, Guid subjectId)
        {
            using (var context = new OnlineAssessmentContext())
            {
                Subject subject = context.Subjects.Find(subjectId);
                Student student = context.Students.Find(userId);
                if (student.LearningSubjects.Contains(subject))
                {
                    IEnumerable<Examination> examinations = subject.Examinations
                        .Where(e => e.State == ExaminationState.Normal)
                        .Where(e => !e.AnswerSheets.Select(a => a.Student.Id).Contains(student.Id));
                    return examinations.ToList();
                }

                return Enumerable.Empty<Examination>().ToList();
            }
        }
    }
}