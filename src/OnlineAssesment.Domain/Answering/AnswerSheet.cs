using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class AnswerSheet
    {
        public AnswerSheet() {
            AnswerItems = new List<AnswerSheetItem>();
        }

        public int AnswerSheetId { get; set; }

        public DateTime SubmitDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Examination Examination { get; set; }
        public virtual ICollection<AnswerSheetItem> AnswerItems { get; set; }
    }
}
