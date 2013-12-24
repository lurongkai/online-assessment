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

        public Guid ExaminationId { get; set; }
        public string Description { get; set; }
        public CourseLevel CourseLevel { get; set; }
        public DateTime BeginDate { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<ExaminationQuestion> Questions { get; set; }
        public ExaminationState State { get; set; }

        public int TotalScore {
            get {
                return Questions.Sum(q => q.Score);
            }
        }
    }
}
