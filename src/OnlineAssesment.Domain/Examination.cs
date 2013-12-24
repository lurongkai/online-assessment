using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class Examination
    {
        public Guid ExaminationId { get; set; }
        public DateTime BeginDate { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ExaminationState State { get; set; }
    }
}
