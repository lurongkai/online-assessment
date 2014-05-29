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
        public Guid GenerateRandomExaminationPaper(ExaminationPaperConfig config) {
            using (var context = new OnlineAssessmentContext()) {
                var questions = context
                    .Questions
                    .Include(q => q.QuestionOptions)
                    .Where(q => q.Subject.SubjectId == config.SubjectId);
                var generator = new RandomExaminationGenerationService(questions);

                var paper = generator.GenerateExaminationPaper(config.AsPaperConstraint());
                context.ExaminationPapers.Add(paper);
                context.SaveChanges();

                return paper.ExaminationPaperId;
            }
        }

        public Guid AddExamination(Guid examinationPaperId, ExaminationConfig examinationPaper) {
            using (var context = new OnlineAssessmentContext()) {
                var paper = context.ExaminationPapers.Find(examinationPaperId);
                var examination = new Examination();
                examination.BeginDate = examinationPaper.BeginDate;
                examination.DueDate = examinationPaper.EndDate;
                examination.Duration = examinationPaper.Duration.TotalMinutes;
                examination.Paper = paper;

                if (examinationPaper.BeginImmediately) {
                    examination.State = ExaminationState.Active;
                } else {
                    examination.State = ExaminationState.Pending;
                }

                context.Examinations.Add(examination);
                context.SaveChanges();

                return examination.ExaminationId;
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

        public ICollection<Examination> GetAvailableExaminations(string userId, Guid subjectId) {
            using (var context = new OnlineAssessmentContext()) {
                var subject = context.Subjects.Find(subjectId);
                var student = context.Students.Find(userId);
                if (student.LearningSubjects.Contains(subject)) {
                    var examinations = subject.Examinations
                        .Where(e => e.State == ExaminationState.Active)
                        .Where(e => !e.HasStudentAnswerSheet(student));
                    return examinations.ToList();
                }

                return Enumerable.Empty<Examination>().ToList();
            }
        }
    }
}