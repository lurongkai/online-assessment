namespace Oas.Models
{
    public class TeacherMenuViewModel
    {
        public int QuestionCount { get; set; }
        public int PaperCount { get; set; }

        public int PendingExamCount { get; set; }
        public int ActiveExamCount { get; set; }
        public int ArchivedExamCount { get; set; }
    }
}