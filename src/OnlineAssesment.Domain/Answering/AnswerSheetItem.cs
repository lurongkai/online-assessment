using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class AnswerSheetItem
    {
        public int AnswerSheetItemId { get; set; }

        public Guid QuestionId { get; set; }
        public string Answer { get; set; }

        public virtual ExaminationQuestion Question { get; set; }
    }
}
