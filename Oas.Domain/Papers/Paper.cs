using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Domain
{
    public class Paper
    {
        public Paper() {
            SelectableQuestions = new List<SelectableQuestion>();
            SubjectiveQuestions = new List<SubjectiveQuestion>();
        }

        public Guid PaperId { get; set; }

        public ICollection<SelectableQuestion> SelectableQuestions { get; set; }
        public ICollection<SubjectiveQuestion> SubjectiveQuestions { get; set; }
    }
}
