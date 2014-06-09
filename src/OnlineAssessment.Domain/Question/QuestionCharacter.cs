using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessment.Domain
{
    public class QuestionCharacter
    {
        public Guid QuestionId { get; set; }
        public QuestionForm QuestionForm { get; set; }
        public int Score { get; set; }
        public double QuestionDegree { get; set; }


        public double AvarageDegreeFactor {
            get { return QuestionDegree * Score; }
        }
    }
}
