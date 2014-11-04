using System;
using System.Collections.Generic;
using System.Linq;
using Oas.Infrastructure;
using Oas.Service.Interfaces;

namespace Oas.Service.Impl
{
    public class ManagementService : IManagementService
    {
        private OasContext _oasContext;

        public ManagementService(OasContext oasContext) {
            _oasContext = oasContext;
        }

        public IEnumerable<Domain.Application.News> GetTopNews(int count) {
            return _oasContext.News
                .OrderByDescending(n => n.PublishedDate)
                .Take(count);
        }

        public Domain.Application.News GetNews(Guid newsId) {
            throw new NotImplementedException();
        }

        public Guid CreateNews(Domain.Application.News news) {
            _oasContext.News.Add(news);
            _oasContext.SaveChanges();

            return news.NewsId;
        }

        public void ModifyNews(Guid newsId, Domain.Application.News news) {
            var old = _oasContext.News.Find(newsId);
            old.Content = news.Content;
            old.Title = news.Title;
            old.PublishedDate = DateTime.Now;

            _oasContext.SaveChanges();
        }

        public void DeleteNews(Guid newsId) {
            var old = _oasContext.News.Find(newsId);
            _oasContext.News.Remove(old);
            _oasContext.SaveChanges();
        }

        public void CreateTeacher(Domain.Teacher teacher) {
            _oasContext.Teachers.Add(teacher);
            _oasContext.SaveChanges();
        }

        public void CreateStudent(Domain.Student student) {
            _oasContext.Students.Add(student);
            _oasContext.SaveChanges();
        }

        public void SubscribeCourse(Guid studentId, string courseId) {
            _oasContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            var student = _oasContext.Students.Find(studentId);
            var course = _oasContext.Courses.Find(courseId);

            student.Subscribe(course);

            _oasContext.SaveChanges();
        }

        public void AssigningCourse(Guid teacherId, string courseId) {
            var teacher = _oasContext.Teachers.Find(teacherId);
            var course = _oasContext.Courses.Find(courseId);

            teacher.Teach(course);

            _oasContext.SaveChanges();
        }
    }
}