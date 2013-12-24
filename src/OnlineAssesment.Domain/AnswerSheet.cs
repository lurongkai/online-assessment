using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class AnswerSheet
    {
        public Guid AnswerSheetId { get; set; }
        public ICollection<AnswerSheetItem> AnswerItems { get; set; }
        public DateTime SubmitDate { get; set; }
        public virtual Examination Examination { get; set; }
    }
}
