using System;
using System.Collections.Generic;
using Oas.Domain;

namespace Oas.Service.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllSubjects();

        IEnumerable<Course> GetStudentCourses(Guid studentId);
        Course GetTeacherTeachCourse(Guid teacherId);

        Guid CreateSubject(Guid courseId,  Subject subject);
        void ModifySubject(Guid subjectId, Subject subject);
        void DeleteSubject(Guid subjectId);

        void PinSubject(Guid subjectId);

        IEnumerable<Subject> GetCoursePinnedSubject(Guid courseId);
    }
}