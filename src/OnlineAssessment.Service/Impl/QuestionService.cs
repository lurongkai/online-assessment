using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;

namespace OnlineAssessment.Service
{
    public class QuestionService : IQuestionService
    {
        public IEnumerable<Question> GetAllQuestion(Guid subjectId, QuestionForm? questionType = null) {
            var context = new OnlineAssessmentContext();
            IQueryable<Question> courseQuestions = context
                .Questions
                .Where(q => q.Subject.SubjectId == subjectId)
                .Where(q => questionType == null || q.QuestionForm == questionType);

            return courseQuestions;
        }

        public Guid AddQuestion(Guid subjectId, Question question) {
            var context = new OnlineAssessmentContext();
            Subject subject = context.Subjects.Find(subjectId);
            subject.Questions.Add(question);
            context.SaveChanges();

            return question.QuestionId;
        }

        public void ModifyQuestion(Question question) {
            var context = new OnlineAssessmentContext();
            context.Questions.Attach(question);
            context.Entry(question).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteQuestion(Guid questionId) {
            var context = new OnlineAssessmentContext();
            Question question = context.Questions.Find(questionId);
            context.Questions.Remove(question);
            context.SaveChanges();
        }
    }
}