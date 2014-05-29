using System;
using System.Collections.Generic;

namespace OnlineAssessment.Domain
{
    public class Examination
    {
        public Examination() {
            ExaminationId = Guid.NewGuid();
        }

        public Guid ExaminationId { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? DueDate { get; set; }
        public double Duration { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ExaminationPaper Paper { get; set; }
        public virtual ICollection<AnswerSheet> AnswerSheets { get; set; }

        public ExaminationState State { get; set; }
    }
}