using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAssessment.Domain.Service.ExaminationGeneration
{
    public class RandomExaminationGenerationService
    {
        private ICollection<Question> _allQuestion;
        public RandomExaminationGenerationService(ICollection<Question> allQuestion)
        {
            _allQuestion = allQuestion;
        }

        public Examination GeneratePaper(PaperConstraint paperConstraint)
        {
			InitializeQuestionPopulation (10, paperConstraint, _allQuestion);
            throw new NotImplementedException();
        }

        #region Initialize Question Population
        private IEnumerable<QuestionPopulation> InitializeQuestionPopulation(
            int populationAmount,
            PaperConstraint paperConstraint, 
            ICollection<Question> questions)
        {
            for (int polulationIndex = 0; polulationIndex < populationAmount; polulationIndex++)
            {
                var population = new QuestionPopulation(paperConstraint);

                while (paperConstraint.TotalScore != population.TotalScore)
                {
                    population.ClearAllQuestions();
                    foreach (var quota in paperConstraint.QuestionQuota)
                    {
                        var questionForm = quota.Key;
                        var questionAmount = quota.Value;
                        var candidateQuestions = questions.Where(q => q.QuestionForm == questionForm).ToList();

                        population.Questions.AddRange(TakeRandomAmountQuestions(candidateQuestions, questionAmount));
                    }
                }

                yield return population;
            }
        }

        private IEnumerable<ExaminationQuestion> TakeRandomAmountQuestions(List<Question> candidateQuestions, int questionAmount)
        {
            var r = new Random();
            for (int questionIndex = 0; questionIndex < questionAmount; questionIndex ++)
            {
                var rLocation = r.Next(0, candidateQuestions.Count - questionIndex);
                yield return candidateQuestions[rLocation].ConvertToExaminationQuestion();

                var temp = candidateQuestions[candidateQuestions.Count - 1 - questionIndex];
                candidateQuestions[candidateQuestions.Count - 1 - questionIndex] = candidateQuestions[rLocation];
                candidateQuestions[rLocation] = temp;
            }
        }
        #endregion

        #region Question Population Operators
        private List<QuestionPopulation> SelectOperation(List<QuestionPopulation> populations, int amount)
        {
            var selectedPopulations = new List<QuestionPopulation>();

            double totalAdaptationDegree = selectedPopulations.Sum(p => p.AdaptationDegree);

            var r = new Random();
            while (selectedPopulations.Count != amount)
            {
                double acc = 0.00;
                double shot = r.Next(1, 100) * 0.01 * totalAdaptationDegree;

                foreach (QuestionPopulation population in populations)
                {
                    acc += population.AdaptationDegree;
                    if (acc >= shot)
                    {
                        if (!selectedPopulations.Contains(population))
                        {
                            selectedPopulations.Add(population);
                        }
                        break;
                    }
                }
            }
            return selectedPopulations;
        }

		private List<QuestionPopulation> Cross(List<QuestionPopulation> populations, int amount)
		{
			var crossedUnitList = new List<QuestionPopulation>();
			var r = new Random();

			while (crossedUnitList.Count != amount)
			{
				int r1 = r.Next(0, populations.Count);
				int r2 = r.Next(0, populations.Count);

				if (r1 == r2) { continue; }

				var population1 = populations[r1];
				var population2 = populations[r2];

				int crossPosition = r.Next(0, population1.QuestionCount - 2);

				var questionScore1 = population1.Questions[crossPosition].Score + population1.Questions[crossPosition + 1].Score;
				var questionScore2 = population2.Questions[crossPosition].Score + population2.Questions[crossPosition + 1].Score;

				if (questionScore1 == questionScore2) { continue; }

				for (int i = crossPosition; i < crossPosition + 2; i++)
				{
					var temp = population1.Questions [i];
					population1.Questions[i] = population2.Questions[i];
					population2.Questions[i] = temp;
				}

				if (crossedUnitList.Count < amount) { crossedUnitList.Add(population1); }
				if (crossedUnitList.Count < amount) { crossedUnitList.Add(population2); }

				crossedUnitList = crossedUnitList.Distinct (new PopulationComparer()).ToList ();
			}

			return crossedUnitList;
		}

        #endregion
    }

    internal class QuestionPopulation
    {
        private readonly PaperConstraint _paperConstraint;
        public QuestionPopulation(PaperConstraint paperConstraint)
        {
            _paperConstraint = paperConstraint;

            Questions = new List<ExaminationQuestion>();
        }

        public List<ExaminationQuestion> Questions { get; set; }

        public int TotalScore {
            get { return Questions.Sum(q => q.Score); }
        }

        public double Degree
        {
            get { return Questions.Sum(q => q.AvarageDegree) / TotalScore; }
        }

        public double AdaptationDegree
        {
            get
            {
                return Questions.Count == 0
                    ? 0.00
                    : 1 - Math.Abs(_paperConstraint.Degree - Degree);
            }
        }

		internal int QuestionCount {
			get { return Questions.Count; }
		}

        internal void ClearAllQuestions()
        {
            Questions.Clear();
        }
    }

    public class PaperConstraint
    {
        public PaperConstraint(
            int totalScore,
            double degree,
            IDictionary<QuestionForm, int> questionQuota
            )
        {
            TotalScore = totalScore;
            Degree = degree;
            QuestionQuota = questionQuota;
        }

        public int TotalScore { get; private set; }
        public double Degree { get; private set; }
        public IDictionary<QuestionForm, int> QuestionQuota { get; private set; }
    }

	internal class PopulationComparer : IEqualityComparer<QuestionPopulation>
	{
		public bool Equals(QuestionPopulation x, QuestionPopulation y)
		{
			bool result = true;
			for (int i = 0; i < x.QuestionCount; i++)
			{
				if (x.Questions[i].QuestionId != y.Questions[i].QuestionId)
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
