using System;

namespace Oas.Domain
{
    public class SubjectiveQuestion : Question, IAggregateRoot<SubjectiveQuestion>
    {
        public string Answer { get; set; }

        public override int Evaluate() {
            throw new NotImplementedException();
        }
    }
}