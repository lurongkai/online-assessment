using System;
using System.Collections.Generic;

namespace OnlineAssessment.Domain.N
{
    public class Option : ValueObject
    {
        public Guid OptionId { get; set; }
        public string Content { get; set; }

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Content;
        }
    }
}