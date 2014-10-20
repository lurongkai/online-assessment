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
            throw new NotImplementedException();
        }

        public void CreateCourse(Domain.Course course) {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Subject> GetCourseSubjects(string courseId) {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Subject> GetCoursePinnedSubject(string courseId) {
            throw new NotImplementedException();
        }
    }
}
