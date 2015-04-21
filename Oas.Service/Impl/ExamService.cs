﻿using System;
using System.Linq;
using Oas.Domain;
using Oas.Domain.Service;
using Oas.Infrastructure;
using Oas.Service.Interfaces;

namespace Oas.Service.Impl
{
    public class ExamService : IExamService
    {
        private OasContext _oasContext;

        public ExamService(OasContext oasContext) {
            _oasContext = oasContext;
        }

        public Paper GeneratePaper(string courseId, string style) {
            var bag = new QuestionTicketBag();
            bag.SingleSelectionQuestions = _oasContext.SelectableQuestions
                .Where(q => q.BelongTo.CourseId == courseId)
                .Where(q => q.Options.Count(o => o.IsRight) == 1)
                .Select(q => new QuestionTicket {QuestionId = q.QuestionId, Score = q.Score, Degree = q.Degree});
            bag.MultipleSelectionQuestions = _oasContext.SelectableQuestions
                .Where(q => q.BelongTo.CourseId == courseId)
                .Where(q => q.Options.Count(o => o.IsRight) > 1)
                .Select(q => new QuestionTicket {QuestionId = q.QuestionId, Score = q.Score, Degree = q.Degree});
            bag.SubjectiveQuestions = _oasContext.SubjectiveQuestions
                .Where(q => q.BelongTo.CourseId == courseId)
                .Select(q => new QuestionTicket {QuestionId = q.QuestionId, Score = q.Score, Degree = q.Degree});
            
            var singleCount = 20;
            var multipleCount = 20;
            var subjectiveCount = 5;

            IPaperGenerationService service = null;
            if (style.ToLower() == "random") {
                service = new RandomPaperGenerationService(bag);
                singleCount = 0;
                multipleCount = 0;
            }
            if (style.ToLower() == "simple") {
                service = new SimplePaperGenerationService(bag);
                subjectiveCount = 0;
            }

            if (service == null) {
                throw new InvalidOperationException("wrong style.");
            }

            var paper = new Paper();
            var singles = service.GenerateSingleSelectionQuestions(singleCount).ToArray();
            var multiples = service.GenerateMultipleSelectionQuestions(multipleCount).ToArray();
            var subjectives = service.GenerateSubjectiveSelectionQuestions(subjectiveCount).ToArray();
            paper.SingleQuestions = _oasContext.SelectableQuestions.Where(q => singles.Contains(q.QuestionId)).ToList();
            paper.MultipleQuestions = _oasContext.SelectableQuestions.Where(q => multiples.Contains(q.QuestionId)).ToList();
            paper.SubjectiveQuestions = _oasContext.SubjectiveQuestions.Where(q => subjectives.Contains(q.QuestionId)).ToList();

            return paper;
        }
        
        public Guid UploadAnswerSheet(string courseId, Guid studentId, AnswerSheet answerSheet)
        {
            var course = _oasContext.Courses.Find(courseId);
            var student = _oasContext.Students.Find(studentId);

            answerSheet.Course = course;
            answerSheet.Student = student;
            answerSheet.Timestamp = DateTime.Now;

            _oasContext.AnswerSheets.Add(answerSheet);
            _oasContext.SaveChanges();

            return answerSheet.AnswerSheetId;
        }

        public void PreEvaluation(Guid answerSheetId)
        {
            var answerSheet = _oasContext.AnswerSheets
                .Include("SelectableQuestionAnswers.Question")
                .Include("SubjectiveQuestionAnswers.Question")
                .SingleOrDefault(a => a.AnswerSheetId == answerSheetId);
            answerSheet.PreEvaluate();
            _oasContext.SaveChanges();
        }

        public System.Collections.Generic.IEnumerable<AnswerSheet> GetStudentAnswerSheets(Guid studentId)
        {
            return _oasContext.AnswerSheets.Where(a => a.Student.MemberId == studentId);
        }

        public System.Collections.Generic.IEnumerable<AnswerSheet> GetUnevaluatedAnswerSheets(string courseId)
        {
            throw new NotImplementedException();
        }

        public void EvaluateAnswerSheet(Guid answerSheetId, Messages.AnswerSheetScore score)
        {
            throw new NotImplementedException();
        }
    }
}