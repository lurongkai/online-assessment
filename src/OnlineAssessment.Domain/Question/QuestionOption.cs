using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAssessment.Domain
{
    public class QuestionOption : ICanMigrate
    {
        public Guid QuestionOptionId { get; set; }

        public string Description { get; set; }
        public bool IsRightAnswer { get; set; }
    }
}
