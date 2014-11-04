using System;
using System.Collections.Generic;

namespace OnlineAssessment.Domain.N
{
    public class SelectableQuestion : Question
    {
        public SelectableQuestion() {
            Options = new List<Option>();
        }

        public ICollection<Option> Options { get; set; }

        public override int Evaluate() {
            throw new NotImplementedException();
        }
    }
}