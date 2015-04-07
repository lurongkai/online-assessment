using System;
using System.Collections.Generic;
using System.Linq;
using Oas.Infrastructure;
using Oas.Service.Interfaces;

namespace Oas.Service.Impl
{
    public class CourseService : ICourseService
    {
        private OasContext _oasContext;

        public CourseService(OasContext oasContext) {
            _oasContext = oasContext;
        }

        public IEnumerable<Domain.Course> GetAllCourses() {
            return _oasContext.Courses;
        }

        public Domain.Course GetCourse(string courseId) {
            return _oasContext.Courses.Find(courseId);
        }

        public IEnumerable<Domain.Course> GetStudentCourses(Guid studentId) {
            var student = _oasContext.Students.Find(studentId);
            return student.SubscribeCourses;
        }

        public Domain.Course GetTeacherTeachCourse(Guid teacherId) {
            var teacher = _oasContext.Teachers.Find(teacherId);
            return teacher.TeachCourse;
        }

        public string CreateCourse(Domain.Course course) {
            _oasContext.Courses.Add(course);
            _oasContext.SaveChanges();

            return course.CourseId;
        }

        public IEnumerable<Domain.Subject> GetCourseSubjects(string courseId) {
            return _oasContext.Subjects.Where(s => s.BelongTo.CourseId == courseId);
        }

        public Guid CreateSubject(string courseId, Domain.Subject subject) {
            var course = _oasContext.Courses.Find(courseId);
            if (!_oasContext.Subjects.Any(s => s.BelongTo.CourseId == courseId)) {
                subject.ForSimulation = true;
            }

            subject.BelongTo = course;
            _oasContext.Subjects.Add(subject);
            _oasContext.SaveChanges();
            return subject.SubjectId;
        }

        public void ModifySubject(Guid subjectId, Domain.Subject subject) {
            var old = _oasContext.Subjects.Find(subjectId);
            old.Name = subject.Name;

            _oasContext.SaveChanges();
        }

        public void DeleteSubject(Guid subjectId) {
            var old = _oasContext.Subjects.Find(subjectId);
            _oasContext.Subjects.Remove(old);

            _oasContext.SaveChanges();
        }

        public void SetSimulation(string courseId, Guid subjectId) {
            var subjects = _oasContext.Subjects.Where(s => s.BelongTo.CourseId == courseId);

            foreach (var subject in subjects) {
                if (subject.SubjectId == subjectId) {
                    subject.ForSimulation = true;
                } else {
                    subject.ForSimulation = false;
                }
            }

            _oasContext.SaveChanges();
        }
    }
}