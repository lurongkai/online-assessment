using OnlineAssessment.Domain;

namespace OnlineAssessment.Web.Extensions
{
    public static class QuestionExtension
    {
        public static string GetString(this QuestionForm questionType) {
            switch (questionType) {
                case QuestionForm.SingleSelection:
                    return "单选题";
                case QuestionForm.MultipleSelection:
                    return "多选题";
                case QuestionForm.Subjective:
                    return "主观题";
                default:
                    return "Unknown";
            }
        }
    }
}