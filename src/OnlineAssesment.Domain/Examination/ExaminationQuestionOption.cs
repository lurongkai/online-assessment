using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class ExaminationQuestionOption
    {
        public int ExaminationQuestionOptionId { get; set; }

        public int OptionIndex { get; set; }
        public string Description { get; set; }
        public bool IsRightAnswer { get; set; }
    }
}
