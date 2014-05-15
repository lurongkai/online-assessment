using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class AnswerSheetItem
    {
        public AnswerSheetItem()
        {
            AnswerSheetItemId = Guid.NewGuid();
            Choices = new List<ExaminationQuestionOption>();
        }
        public Guid AnswerSheetItemId { get; set; }

        public string Answer { get; set; }
        public virtual ICollection<ExaminationQuestionOption> Choices { get; set; }

        public virtual ExaminationQuestion ExaminationQuestion { get; set; }
        public int? ObtainedScore { get; set; }
    }
}
