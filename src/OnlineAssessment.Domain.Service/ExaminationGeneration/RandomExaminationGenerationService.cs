using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessment.Domain.Service.ExaminationGeneration
{
    public class RandomExaminationGenerationService
    {
        private readonly IEnumerable<Question> _allQuestion;

        public RandomExaminationGenerationService(IEnumerable<Question> allQuestion) {
            _allQuestion = allQuestion;
        }

        public ExaminationPaper GenerateExaminationPaper(PaperConstraint paperConstraint, int populationAmount = 10,
            int maxCaculationCount = 500) {
            List<QuestionPopulation> populations =
                InitializeQuestionPopulation(populationAmount, paperConstraint, _allQuestion).ToList();

            while (maxCaculationCount != 0) {
                populations = SelectOperation(populations, 10);
                populations = CrossOperation(populations, 20);

                if (populations.Any(p => p.AdaptationDegree > paperConstraint.ExpectedAdaptationDegree)) {
                    QuestionPopulation resultPopulation =
                        populations.First(p => p.AdaptationDegree > paperConstraint.ExpectedAdaptationDegree);
                    return GenerateExamination(resultPopulation);
                }

                populations = ChangeOperation(populations, _allQuestion);

                maxCaculationCount--;
            }

            throw new InvalidOperationException("no results.");
        }

        private ExaminationPaper GenerateExamination(QuestionPopulation resultPopulation) {
            throw new NotImplementedException();
        }

        #region Initialize Question Population

        private IEnumerable<QuestionPopulation> InitializeQuestionPopulation(
            int populationAmount,
            PaperConstraint paperConstraint,
            IEnumerable<Question> questions) {
            for (int polulationIndex = 0; polulationIndex < populationAmount; polulationIndex++) {
                var population = new QuestionPopulation(paperConstraint);

                while (paperConstraint.TotalScore != population.TotalScore) {
                    population.ClearAllQuestions();
                    foreach (var quota in paperConstraint.QuestionQuota) {
                        QuestionForm questionForm = quota.Key;
                        int questionAmount = quota.Value;
                        List<Question> candidateQuestions =
                            questions.Where(q => q.QuestionForm == questionForm).ToList();

                        population.Questions.AddRange(TakeRandomAmountQuestions(candidateQuestions, questionAmount));
                    }
                }

                yield return population;
            }
        }

        private IEnumerable<PaperQuestion> TakeRandomAmountQuestions(List<Question> candidateQuestions,
            int questionAmount) {
            var r = new Random();
            for (int questionIndex = 0; questionIndex < questionAmount; questionIndex++) {
                int rLocation = r.Next(0, candidateQuestions.Count - questionIndex);
                yield return candidateQuestions[rLocation].ConvertToExaminationQuestion();

                Question temp = candidateQuestions[candidateQuestions.Count - 1 - questionIndex];
                candidateQuestions[candidateQuestions.Count - 1 - questionIndex] = candidateQuestions[rLocation];
                candidateQuestions[rLocation] = temp;
            }
        }

        #endregion

        #region Question Population Operators

        private List<QuestionPopulation> SelectOperation(List<QuestionPopulation> populations, int amount) {
            var selectedPopulations = new List<QuestionPopulation>();

            double totalAdaptationDegree = selectedPopulations.Sum(p => p.AdaptationDegree);

            var r = new Random();
            while (selectedPopulations.Count != amount) {
                double acc = 0.00;
                double shot = r.Next(1, 100)*0.01*totalAdaptationDegree;

                foreach (QuestionPopulation population in populations) {
                    acc += population.AdaptationDegree;
                    if (acc >= shot) {
                        if (!selectedPopulations.Contains(population)) {
                            selectedPopulations.Add(population);
                        }
                        break;
                    }
                }
            }
            return selectedPopulations;
        }

        private List<QuestionPopulation> CrossOperation(List<QuestionPopulation> populations, int amount) {
            var crossedUnitList = new List<QuestionPopulation>();
            var r = new Random();

            while (crossedUnitList.Count != amount) {
                int r1 = r.Next(0, populations.Count);
                int r2 = r.Next(0, populations.Count);

                if (r1 == r2) {
                    continue;
                }

                QuestionPopulation population1 = populations[r1];
                QuestionPopulation population2 = populations[r2];

                int crossPosition = r.Next(0, population1.QuestionCount - 2);

                int questionScore1 = population1.Questions[crossPosition].Score +
                                     population1.Questions[crossPosition + 1].Score;
                int questionScore2 = population2.Questions[crossPosition].Score +
                                     population2.Questions[crossPosition + 1].Score;

                if (questionScore1 == questionScore2) {
                    continue;
                }

                for (int i = crossPosition; i < crossPosition + 2; i++) {
                    PaperQuestion temp = population1.Questions[i];
                    population1.Questions[i] = population2.Questions[i];
                    population2.Questions[i] = temp;
                }

                if (crossedUnitList.Count < amount) {
                    crossedUnitList.Add(population1);
                }
                if (crossedUnitList.Count < amount) {
                    crossedUnitList.Add(population2);
                }

                crossedUnitList = crossedUnitList.Distinct(new PopulationComparer()).ToList();
            }

            return crossedUnitList;
        }

        private List<QuestionPopulation> ChangeOperation(List<QuestionPopulation> populations,
            IEnumerable<Question> questions) {
            var r = new Random();

            foreach (QuestionPopulation population in populations) {
                int rIndex = r.Next(0, population.QuestionCount);
                PaperQuestion question = population.Questions[rIndex];

                IEnumerable<Question> candidateQuestions = questions
                    .Where(q => q.Score == question.Score)
                    .Where(q => q.QuestionForm == question.QuestionForm);

                if (candidateQuestions.Count() > 0) {
                    int rCandidateIndex = r.Next(0, candidateQuestions.Count());
                    population.Questions[rIndex] = questions.ElementAt(rCandidateIndex).ConvertToExaminationQuestion();
                }
            }

            return populations;
        }

        #endregion
    }
}