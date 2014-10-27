namespace Oas.Domain
{
    public class Teacher : Member
    {
        public virtual Course TeachCourse { get; set; }

        public void Teach(Course course) {
            TeachCourse = course;
        }
    }
}