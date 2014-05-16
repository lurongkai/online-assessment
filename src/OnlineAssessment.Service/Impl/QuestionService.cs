using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Service
{
    public class QuestionService : IQuestionService
    {
        public IEnumerable<Question> GetAllQuestion(Guid subjectId, QuestionType? questionType = null) {
            var context = new OnlineAssessmentContext();
            var courseQuestions = context
                .Questions
                .Where(q => q.Subject.SubjectId == subjectId)
                .Where(q => questionType == null ? true : q.QuestionType == questionType);

            return courseQuestions;
        }

        public Guid AddQuestion(Question question) {
            var context = new OnlineAssessmentContext();
            context.Questions.Add(question);
            context.SaveChanges();

            return question.QuestionId;
        }

        public void ModifyQuestion(Question question) {
            var context = new OnlineAssessmentContext();
            context.Questions.Attach(question);
            context.SaveChanges();
        }

        public void DeleteQuestion(Guid questionId) {
            var context = new OnlineAssessmentContext();
            var question = context.Questions.Find(questionId);
            context.Questions.Remove(question);
            context.SaveChanges();
        }
    }
}
