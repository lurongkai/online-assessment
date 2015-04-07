using System;
using System.Collections.Generic;
using Oas.Domain;

namespace Oas.Service.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourse(string courseId);

        IEnumerable<Course> GetStudentCourses(Guid studentId);
        Course GetTeacherTeachCourse(Guid teacherId);
        string CreateCourse(Course course);

        IEnumerable<Subject> GetCourseSubjects(string courseId);
        Guid CreateSubject(string courseId, Subject subject);
        void ModifySubject(string subjectId, Subject subject);
        void DeleteSubject(string subjectId);
    }
}