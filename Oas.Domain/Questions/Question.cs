using System;

namespace Oas.Domain
{
    public abstract class Question
    {
        public Guid QuestionId { get; set; }

        public string Body { get; set; }
        public int Score { get; set; }

        public abstract int Evaluate();
    }
}