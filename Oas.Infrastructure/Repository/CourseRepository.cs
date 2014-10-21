using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oas.Domain.Repository;

namespace Oas.Infrastructure.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private OasContext _oasContext;
        public CourseRepository(OasContext oasContext) {
            _oasContext = oasContext;
        }

        public Domain.Course FindCourse(string courseId) {
            return _oasContext.Courses.Find(courseId);
        }

        public void CreateCourse(Domain.Course course) {
            _oasContext.Courses.Add(course);
            _oasContext.SaveChanges();
        }

        public IEnumerable<Domain.Subject> GetCourseSubjects(string courseId) {
            return _oasContext.Subjects.Where(s => s.BelongTo.CourseId == courseId);
        }

        public IEnumerable<Domain.Subject> GetCoursePinnedSubject(string courseId) {
            throw new NotImplementedException();
        }
    }
}
