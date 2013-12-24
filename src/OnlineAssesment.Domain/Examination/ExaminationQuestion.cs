using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class ExaminationQuestion
    {
        public int ExaminationQuestionId { get; set; }

        public Guid QuestionId { get; set; }
        public int QuestionIndex { get; set; }
        public int Score { get; set; }

        public string QuestionBody { get; set; }
        public ICollection<ExaminationQuestionOption> QuestionOptions { get; set; }
        public string ReferenceRightAnswer { get; set; }
    }
}
