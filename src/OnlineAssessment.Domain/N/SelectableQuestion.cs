using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Domain.N
{
    public class SelectableQuestion : Question
    {

        public ICollection<Option> Options { get; set; }
    }
}
