using System.Collections.Generic;

namespace OnlineAssessment.Domain.Service.PaperGeneration
{
    public class PaperConstraint
    {
        public PaperConstraint(
            int totalScore,
			double expectedDegree,
            IDictionary<QuestionForm, int> questionQuota
            ) {
            TotalScore = totalScore;
			ExpectedDegree = expectedDegree;
            QuestionQuota = questionQuota;
        }

        public int TotalScore { get; private set; }
        public double ExpectedDegree { get; private set; }
        public IDictionary<QuestionForm, int> QuestionQuota { get; private set; }
    }
}