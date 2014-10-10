using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
