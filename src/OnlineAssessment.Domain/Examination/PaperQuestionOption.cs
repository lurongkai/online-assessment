using System;

namespace OnlineAssessment.Domain
{
    public class PaperQuestionOption
    {
        public PaperQuestionOption()
        {
            ExaminationQuestionOptionId = Guid.NewGuid();
        }

        public Guid ExaminationQuestionOptionId { get; set; }
        public int OptionIndex { get; set; }
        public string Description { get; set; }
        public bool IsRightAnswer { get; set; }
    }
}