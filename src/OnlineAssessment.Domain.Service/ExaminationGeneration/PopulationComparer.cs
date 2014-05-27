using System.Collections.Generic;

namespace OnlineAssessment.Domain.Service.ExaminationGeneration
{
    internal class PopulationComparer : IEqualityComparer<QuestionPopulation>
    {
        public bool Equals(QuestionPopulation x, QuestionPopulation y)
        {
            bool result = true;
            for (int i = 0; i < x.QuestionCount; i++)
            {
                if (x.Questions[i].PaperQuestionId != y.Questions[i].PaperQuestionId)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public int GetHashCode(QuestionPopulation obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}