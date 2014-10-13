using System;
using System.Collections.Generic;

namespace Oas.Domain
{
    public class Option : ValueObject
    {
        public Guid OptionId { get; set; }
        public string Content { get; set; }
        public bool IsRight { get; set; }

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Content;
        }
    }
}