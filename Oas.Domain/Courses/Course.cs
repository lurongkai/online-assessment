using System.Collections.Generic;
using System.Linq;

namespace Oas.Domain
{
    public class Course : IAggregateRoot<Course>
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
    }
}