using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Domain
{
    public class ExaminationQuestionOption
    {
        public ExaminationQuestionOption()
        {
            ExaminationQuestionOptionId = Guid.NewGuid();
        }
        public Guid ExaminationQuestionOptionId { get; set; }

        public int OptionIndex { get; set; }
        public string Description { get; set; }
        public bool IsRightAnswer { get; set; }
    }
}
