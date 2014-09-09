using System;

namespace OnlineAssessment.Domain
{
    public class QuestionCharacter
    {
        public Guid QuestionId { get; set; }
        public QuestionForm QuestionForm { get; set; }
        public int QuestionScore { get; set; }
        public double QuestionDegree { get; set; }


        public double AvarageDegreeFactor {
            get { return QuestionDegree*QuestionScore; }
        }
    }
}