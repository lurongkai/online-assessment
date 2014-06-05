using System;
using System.Collections.Generic;

namespace OnlineAssessment.Domain
{
    public class PaperQuestion
    {
        public PaperQuestion() {
            PaperQuestionId = Guid.NewGuid();
            QuestionOptions = new List<PaperQuestionOption>();
        }

        public Guid PaperQuestionId { get; set; }
        public int QuestionIndex { get; set; }
        public int Score { get; set; }
        public double QuestionDegree { get; set; }
        public QuestionForm QuestionForm { get; set; }
        public string QuestionBody { get; set; }
        public string ReferenceRightAnswer { get; set; }
        public ICollection<PaperQuestionOption> QuestionOptions { get; set; }

        public double AvarageDegree {
            get { return QuestionDegree * Score; }
        }
    }
}