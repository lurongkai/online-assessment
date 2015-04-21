using System;
using System.Collections.Generic;
using System.Linq;

namespace Oas.Domain
{
    public class Course : IAggregateRoot<Course>
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public static string GenerateCourseId()
        {
            var prefix = "cous";
            var timePart = DateTime.Now.ToString("yyyy-MMddhhmmss");
            return string.Format("{0}-{1}", prefix, timePart);
        }
    }
}