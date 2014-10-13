using System;

namespace OnlineAssessment.Domain.N
{
    public class Exam
    {
        public Guid ExamId { get; set; }

        public string Description { get; set; }

        public Paper Paper { get; set; }
        public ExamSchedule Schedule { get; set; }
    }
}