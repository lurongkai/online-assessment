using System;

namespace Oas.Domain
{
    public class SubjectiveQuestion : Question
    {
        public string Answer { get; set; }

        public override int Evaluate() {
            throw new NotImplementedException();
        }
    }
}