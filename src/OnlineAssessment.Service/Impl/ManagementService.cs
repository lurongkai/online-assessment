using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;

namespace OnlineAssessment.Service
{
    public class ManagementService : IManagementService
    {
        public ApplicationUser GetProfile(string userId) {
            using (var context = new OnlineAssessmentContext()) {
                var user = context.Users.Find(userId);

                return user;
            }
        }

        public IEnumerable<Subject> GetStudentSubjects(string studentId) {
            using (var context = new OnlineAssessmentContext()) {
                var student = context.Students.Find(studentId);
                return student.LearningSubjects;
            }
        }

        public Subject GetTeacherSubject(string teacherId) {
            using (var context = new OnlineAssessmentContext()) {
                var teacher = context.Teachers.Find(teacherId);
                return teacher.ResponsibleSubject;
            }
        }

        public IEnumerable<News> GetAllNews(int? page, int pageSize = 50) {
            using (var context = new OnlineAssessmentContext()) {
                return context.News.OrderByDescending(n => n.PublishedDate)
                              .Skip(pageSize*(page ?? 1 - 1))
                              .Take(pageSize)
                              .ToList();
            }
        }

        public Guid CreateNews(News news) {
            using (var context = new OnlineAssessmentContext()) {
                context.News.Add(news);
                context.SaveChanges();

                return news.NewsId;
            }
        }

        public void DeleteNews(Guid newsId) {
            using (var context = new OnlineAssessmentContext()) {
                var news = context.News.Find(newsId);
                context.News.Remove(news);

                context.SaveChanges();
            }
        }

        public News GetNews(Guid newsId) {
            using (var context = new OnlineAssessmentContext()) {
                var news = context.News.Find(newsId);
                return news;
            }
        }

        public void EditNews(News modifiedNews) {
            using (var context = new OnlineAssessmentContext()) {
                context.News.Attach(modifiedNews);
                context.Entry(modifiedNews).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}