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
        Guid CreateSubject(string courseId,  Subject subject);
        void ModifySubject(Guid subjectId, Subject subject);
        void DeleteSubject(Guid subjectId);

        void PinSubject(string courseId, Guid subjectId);
        void UnPinSubject(string courseId, Guid subjectId);
        IEnumerable<SubjectPin> GetCoursePinSubjects(string courseId);
    }
}