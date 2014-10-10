using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Domain.N
{
    public abstract class Question
    {
        public Guid QuestionId { get; set; }

        public string Body { get; set; }
        public string Answer { get; set; }

        public int Score { get; set; }

        public abstract int Evaluate();
    }
}
