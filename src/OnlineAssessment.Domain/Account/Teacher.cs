namespace OnlineAssessment.Domain
{
    public class Teacher : ApplicationUser
    {
        public virtual Subject ResponsibleSubject { get; set; }
    }
}