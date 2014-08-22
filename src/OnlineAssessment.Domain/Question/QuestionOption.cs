using System;

namespace OnlineAssessment.Domain
{
    public class QuestionOption : ICanMigrate
    {
        public QuestionOption() {
            QuestionOptionId = Guid.NewGuid();
        }

        public Guid QuestionOptionId { get; set; }
        public string Description { get; set; }
        public bool IsRightAnswer { get; set; }

        internal PaperQuestionOption ConvertToPaperQuestionOption()
        {
            return new PaperQuestionOption()
            {
                Description = Description,
                IsRightAnswer = IsRightAnswer
            };
        }
    }
}