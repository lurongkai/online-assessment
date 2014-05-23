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
}
