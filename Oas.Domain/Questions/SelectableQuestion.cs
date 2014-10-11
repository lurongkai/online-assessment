using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Domain
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
