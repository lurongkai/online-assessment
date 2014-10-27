namespace Oas.Domain
{
    public class Teacher : Member
    {
        public Course TeachCourse { get; set; }

        public void Teach(Course course) {
            throw new System.NotImplementedException();
        }
    }
}