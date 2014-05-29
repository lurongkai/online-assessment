using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessment.Domain
{
    public class ExaminationPaper
    {
        public ExaminationPaper() {
            ExaminationPaperId = Guid.NewGuid();
            Questions = new List<PaperQuestion>();
        }

        public Guid ExaminationPaperId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? DueDate { get; set; }
        public long Duration { get; set; }
        public ExaminationState State { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<PaperQuestion> Questions { get; set; }

        public float TotalScore {
            get { return Questions.Sum(q => q.Score); }
        }
    }
}