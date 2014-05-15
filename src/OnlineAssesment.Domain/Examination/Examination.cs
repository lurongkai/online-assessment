using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class Examination
    {
        public Examination() {
            Questions = new List<ExaminationQuestion>();
        }

        public int ExaminationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Subject Subject { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? DueDate { get; set; }
        public long Duration { get; set; }
        public ExaminationState State { get; set; }

        public virtual ICollection<ExaminationQuestion> Questions { get; set; }

        public int TotalScore {
            get {
                return Questions.Sum(q => q.Score);
            }
        }
    }
}
