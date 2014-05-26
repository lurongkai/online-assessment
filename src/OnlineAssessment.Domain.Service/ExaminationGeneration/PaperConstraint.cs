using System.Collections.Generic;

namespace OnlineAssessment.Domain.Service.ExaminationGeneration
{
    public class PaperConstraint
    {
        public PaperConstraint(
            int totalScore,
            double degree,
            double expectedAdaptationDegree,
            IDictionary<QuestionForm, int> questionQuota
            )
        {
            TotalScore = totalScore;
            Degree = degree;
            ExpectedAdaptationDegree = expectedAdaptationDegree;
            QuestionQuota = questionQuota;
        }

        public int TotalScore { get; private set; }
        public double Degree { get; private set; }
        public double ExpectedAdaptationDegree { get; private set; }
        public IDictionary<QuestionForm, int> QuestionQuota { get; private set; }
    }
}