using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Domain.N
{
    public class Exam
    {
        public Guid ExamId { get; set; }

        public Paper Paper { get; set; }
        public ExamSchedule Schedule { get; set; }
    }
}
