using System.Collections.Generic;

namespace Oas.Domain
{
    public class Student : Member
    {
        public ICollection<Course> SubscribeCourses { get; set; }
    }
}