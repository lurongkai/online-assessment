using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using OnlineAssessment.Domain;
using OnlineAssessment.Domain.Service.ExaminationGeneration;
using OnlineAssessment.Infrastructure;
using OnlineAssessment.Service.Message;

namespace OnlineAssessment.Service
{
    public class ExaminationService : IExaminationService
    {
        public Guid GenerateRandomExaminationPaper(ExaminationPaperConfig config) {
            using (var context = new OnlineAssessmentContext())
            {
                var subject = context.Subjects.Find(config.SubjectKey);
                var questions = context
                    .Questions
                    .Include(q => q.QuestionOptions)
                    .Where(q => q.Subject.SubjectKey == config.SubjectKey);
                var generator = new RandomExaminationGenerationService(questions);

                int populationAmount = 10;
                if (questions.Count() < 10)
                {
                    populationAmount = questions.Count();
                }
                var paper = generator.GenerateExaminationPaper(config.AsPaperConstraint(), populationAmount);
                paper.Title = config.Title;
                paper.Description = config.Description;
                //paper.Subject = subject;

                //context.ExaminationPapers.Add(paper);
                subject.ExaminationPapers.Add(paper);
                context.SaveChanges();

                return paper.ExaminationPaperId;
            }
        }

        public Guid AddExamination(string subjectKey, Guid examinationPaperId, ExaminationConfig examinationPaper) {
            using (var context = new OnlineAssessmentContext())
            {
                var subject = context.Subjects.Find(subjectKey);
                var paper = context.ExaminationPapers.Find(examinationPaperId);

                var examination = new Examination();
                examination.Title = examinationPaper.Title;
                examination.BeginDate = examinationPaper.BeginDate;
                examination.DueDate = examinationPaper.EndDate;
                examination.Duration = examinationPaper.Duration;
                examination.Paper = paper;
                //examination.Subject = subject;

                if (examinationPaper.BeginImmediately) {
                    examination.State = ExaminationState.Active;
                } else {
                    examination.State = ExaminationState.Pending;
                }

                //context.Examinations.Add(examination);
                subject.Examinations.Add(examination);
                context.SaveChanges();

                return examination.ExaminationId;
            }
        }

        public IEnumerable<ExaminationPaper> GetAllExaminationPapers(string subjectKey) {
            using (var context = new OnlineAssessmentContext()) {
                var subject = context.Subjects.Find(subjectKey);
                var papers = subject.ExaminationPapers.ToList();
                return papers;
            }
        }

        public ExaminationPaper GetExaminationPaper(Guid paperId) {
            using (var context = new OnlineAssessmentContext()) {
                var paper = context.ExaminationPapers.Find(paperId);
                return paper;
            }
        }

        public void ActiveExamination(Guid examinationId) {
            using (var context = new OnlineAssessmentContext()) {
                var examination = context.Examinations.Find(examinationId);
                examination.State = ExaminationState.Active;
                context.SaveChanges();
            }
        }

        public void ArchiveExamination(Guid examinationId) {
            using (var context = new OnlineAssessmentContext()) {
                var examination = context.Examinations.Find(examinationId);
                examination.State = ExaminationState.Archived;
                context.SaveChanges();
            }
        }

        public Examination GetExamination(Guid examinationId) {
            using (var context = new OnlineAssessmentContext()) {
                var examination = context.Examinations.Find(examinationId);
                return examination;
            }
        }

        public IEnumerable<Examination> GetAllExaminations(string subjectKey, ExaminationState? examinationState) {
            using (var context = new OnlineAssessmentContext()) {
                var subject = context.Subjects.Find(subjectKey);
                var examination = subject.Examinations
                    //.Where(e => e.Subject.SubjectKey == subjectKey)
                    .Where(e => examinationState == null || e.State == examinationState.Value)
                    .ToList();
                return examination;
            }
        }

        public IEnumerable<Examination> GetStudentAvailableExaminations(string userId, string subjectKey) {
            using (var context = new OnlineAssessmentContext()) {
                var subject = context.Subjects.Find(subjectKey);
                var student = context.Students.Find(userId);
                if (student.LearningSubjects.Contains(subject)) {
                    var examinations = subject.Examinations
                        //.Where(e => e.Subject.SubjectKey == subjectKey)
                        .Where(e => e.State == ExaminationState.Active)
                        .Where(e => !e.HasStudentAnswerSheet(student))
                        .ToList();
                    return examinations;
                }

                return Enumerable.Empty<Examination>();
            }
        }

        public void DeleteExaminationPaper(Guid paperId) {
            using (var context = new OnlineAssessmentContext()) {
                var paper = context.ExaminationPapers.Find(paperId);
                context.ExaminationPapers.Remove(paper);

                context.SaveChanges();
            }
        }
    }
}