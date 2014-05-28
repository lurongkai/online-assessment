using OnlineAssessment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAssessment.Service.Message
{
    public class ExaminationPaperConfig
    {
        public Guid SubjectId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public float Degree { get; set; }
        public int TotalScore { get; set; }

        public int SingleSelectionQuestionQuantity { get; set; }
        public int MutipleSelectionQuestionQuantity { get; set; }
        public int SubjectiveQuestionQuantity { get; set; }
    }

    public class ExaminationConfig
    {
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan Duration { get; set; }

        public bool BeginImmediately { get; set; }
    }
}
