using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessment.Domain
{
    public class Examination
    {
        public Examination() {
            ExaminationId = Guid.NewGuid();
        }

        public Guid ExaminationId { get; set; }
        public string Title { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? DueDate { get; set; }
        public double Duration { get; set; }

        public virtual ExaminationPaper Paper { get; set; }
        public virtual ICollection<AnswerSheet> AnswerSheets { get; set; }

        public ExaminationState State { get; set; }

        public bool HasStudentAnswerSheet(Student student) {
            return AnswerSheets.Any(a => a.Student.Id == student.Id);
        }
    }
}