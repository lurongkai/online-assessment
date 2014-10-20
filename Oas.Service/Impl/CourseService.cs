using Oas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Service.Impl
{
    public class CourseService : ICourseService
    {
        public IEnumerable<Domain.Course> GetAllCourses() {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Course> GetStudentCourses(Guid studentId) {
            throw new NotImplementedException();
        }

        public Domain.Course GetTeacherTeachCourse(Guid teacherId) {
            throw new NotImplementedException();
        }

        public string CreateCourse(Domain.Course course) {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Subject> GetCourseSubjects(string courseId) {
            throw new NotImplementedException();
        }

        public Guid CreateSubject(string courseId, Domain.Subject subject) {
            throw new NotImplementedException();
        }

        public void ModifySubject(Guid subjectId, Domain.Subject subject) {
            throw new NotImplementedException();
        }

        public void DeleteSubject(Guid subjectId) {
            throw new NotImplementedException();
        }

        public void PinSubject(Guid subjectId) {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Subject> GetCoursePinSubjects(string courseId) {
            throw new NotImplementedException();
        }
    }
}
