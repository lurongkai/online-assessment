using System;
using System.Collections.Generic;

namespace Oas.Domain
{
    public class Option
    {
        public Option() {
            OptionId = Guid.NewGuid();
        }

        public Guid OptionId { get; set; }
        public string Content { get; set; }
        public bool IsRight { get; set; }
    }
}