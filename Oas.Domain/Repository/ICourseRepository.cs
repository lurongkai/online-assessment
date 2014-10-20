using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Domain.Repository
{
    public interface ICourseRepository
    {
        Course FindCourse(string courseId);
        void CreateCourse(Course course);

        IEnumerable<Subject> GetCourseSubjects(string courseId);
        IEnumerable<Subject> GetCoursePinnedSubject(string courseId);


    }
}
