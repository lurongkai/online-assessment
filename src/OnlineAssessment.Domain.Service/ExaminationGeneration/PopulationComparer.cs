using System.Collections.Generic;

namespace OnlineAssessment.Domain.Service.ExaminationGeneration
{
    internal class PopulationComparer : IEqualityComparer<QuestionPopulation>
    {
        public bool Equals(QuestionPopulation x, QuestionPopulation y) {
            var result = true;
            for (var i = 0; i < x.QuestionCount; i++) {
                if (x.Questions[i].QuestionId != y.Questions[i].QuestionId) {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public int GetHashCode(QuestionPopulation obj) {
            return obj.ToString().GetHashCode();
        }
    }
}