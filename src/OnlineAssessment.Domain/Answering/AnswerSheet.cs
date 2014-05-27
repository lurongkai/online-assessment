using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Domain
{
    public class AnswerSheet
    {
        public AnswerSheet()
        {
            AnswerSheetId = Guid.NewGuid();
            AnswerItems = new List<AnswerSheetItem>();
        }

        public Guid AnswerSheetId { get; set; }

        public DateTime SubmitDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Examination Examination { get; set; }
        public virtual ICollection<AnswerSheetItem> AnswerItems { get; set; }

        public bool HasFullGrade {
            get {
                return AnswerItems.All(ai => ai.ObtainedScore != null);
            }
        }

        public void Evaluate() {
            foreach (var answerSheetItem in AnswerItems)
            {
                if (answerSheetItem.ObtainedScore.HasValue)
                {
                    continue;
                }

                answerSheetItem.Evaluate();
            }
        }
    }
}
