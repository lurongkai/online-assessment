using System;
using System.Collections.Generic;
using Oas.Domain;

namespace Oas.Service.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        IEnumerable<Course> GetStudentCourses(Guid studentId);
        Course GetTeacherTeachCourse(Guid teacherId);

        IEnumerable<Subject> GetCourseSubjects(string courseId);
        Guid CreateSubject(string courseId,  Subject subject);
        void ModifySubject(Guid subjectId, Subject subject);
        void DeleteSubject(Guid subjectId);

        void PinSubject(Guid subjectId);
        IEnumerable<Subject> GetCoursePinSubjects(string courseId);
    }
}