using System;

namespace Oas.Domain
{
    public class SubjectiveQuestion : Question, IAggregateRoot<SubjectiveQuestion>
    {
        public SubjectiveQuestion() {
            QuestionId = Guid.NewGuid();
        }

        public string Answer { get; set; }

        public override int Evaluate() {
            throw new NotImplementedException();
        }
    }
}