using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessment.Domain.Service.ExaminationGeneration
{
    public class RandomExaminationGenerationService
    {
        private readonly IEnumerable<Question> _allQuestion;
        private readonly int _maxCaculationCount;

        public RandomExaminationGenerationService(IEnumerable<Question> allQuestion, int maxCaculationCount = 500)
        {
            _allQuestion = allQuestion;
            _maxCaculationCount = maxCaculationCount;
        }

        public ExaminationPaper GenerateExaminationPaper(PaperConstraint paperConstraint, int populationAmount = 10) {
            var populations = InitializeQuestionPopulation(populationAmount, paperConstraint, _allQuestion).ToList();

            var counter = _maxCaculationCount;
            while (counter != 0)
            {
                if (populations.Any(p => p.AdaptationDegree > paperConstraint.ExpectedAdaptationDegree)) {
                    var resultPopulation = populations.First(p => p.AdaptationDegree > paperConstraint.ExpectedAdaptationDegree);
                    return GenerateExamination(resultPopulation);
                }

                populations = SelectOperation(populations);
                populations = CrossOperation(populations);

                if (populations.Any(p => p.AdaptationDegree > paperConstraint.ExpectedAdaptationDegree)) {
                    var resultPopulation = populations.First(p => p.AdaptationDegree > paperConstraint.ExpectedAdaptationDegree);
                    return GenerateExamination(resultPopulation);
                }

                populations = ChangeOperation(populations, _allQuestion);

                counter--;
            }

            throw new InvalidOperationException("no results.");
        }

        private ExaminationPaper GenerateExamination(QuestionPopulation resultPopulation)
        {
            var paper = new ExaminationPaper()
            {
                Degree = resultPopulation.Degree,
                Questions = resultPopulation.Questions
            };
            return paper;
        }

        #region Initialize Question Population

        private IEnumerable<QuestionPopulation> InitializeQuestionPopulation(int populationAmount, PaperConstraint paperConstraint, IEnumerable<Question> questions) {
            for (var polulationIndex = 0; polulationIndex < populationAmount; polulationIndex++) {
                var population = new QuestionPopulation(paperConstraint);

                var counter = _maxCaculationCount;
                while (paperConstraint.TotalScore != population.TotalScore) {
                    population.ClearAllQuestions();
                    foreach (var quota in paperConstraint.QuestionQuota) {
                        var questionForm = quota.Key;
                        var questionAmount = quota.Value;
                        var candidateQuestions = questions.Where(q => q.QuestionForm == questionForm).ToList();

                        population.Questions.AddRange(TakeRandomAmountQuestions(candidateQuestions, questionAmount));
                    }
                    counter--;
                    if (counter == 0)
                    {
                        throw new InvalidOperationException("question database not large enough to generate population.");
                    }
                }

                yield return population;
            }
        }

        private IEnumerable<PaperQuestion> TakeRandomAmountQuestions(List<Question> candidateQuestions, int questionAmount) {
            if(candidateQuestions.Count < questionAmount){throw new InvalidOperationException("specfied question form do not have enough questions.");}
            
            var r = new Random();
            for (var questionIndex = 0; questionIndex < questionAmount; questionIndex++) {
                var rLocation = r.Next(0, candidateQuestions.Count - questionIndex);
                yield return candidateQuestions[rLocation].ConvertToExaminationQuestion();

                var temp = candidateQuestions[candidateQuestions.Count - 1 - questionIndex];
                candidateQuestions[candidateQuestions.Count - 1 - questionIndex] = candidateQuestions[rLocation];
                candidateQuestions[rLocation] = temp;
            }
        }

        #endregion

        #region Question Population Operators

        private List<QuestionPopulation> SelectOperation(List<QuestionPopulation> populations) {
            if (populations.Count < 2) { return populations; }
            
            var r = new Random();

            var possibility = r.Next(30, 70) * 0.01;
            var amount = (int)Math.Ceiling(possibility * populations.Count);

            var selectedPopulations = new List<QuestionPopulation>();

            var totalAdaptationDegree = selectedPopulations.Sum(p => p.AdaptationDegree);
            while (selectedPopulations.Count != amount) {
                var acc = 0.00;
                var shot = r.Next(1, 100) * 0.01 * totalAdaptationDegree;

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

        private List<QuestionPopulation> CrossOperation(List<QuestionPopulation> populations) {
            if (populations.Count < 2) { return populations; }

            var crossedUnitList = new List<QuestionPopulation>();
            var r = new Random();

            var possibility = 1 / (r.Next(30, 70) * 0.01);
            var amount = (int)Math.Ceiling(possibility * populations.Count);

            while (crossedUnitList.Count != amount) {
                var r1 = r.Next(0, populations.Count);
                var r2 = r.Next(0, populations.Count);

                if (r1 == r2) {
                    continue;
                }

                var population1 = populations[r1];
                var population2 = populations[r2];

                var crossPosition = r.Next(0, population1.QuestionCount - 2);

                var questionScore1 = population1.Questions[crossPosition].Score +
                                     population1.Questions[crossPosition + 1].Score;
                var questionScore2 = population2.Questions[crossPosition].Score +
                                     population2.Questions[crossPosition + 1].Score;

                if (questionScore1 != questionScore2) {
                    continue;
                }

                for (var i = crossPosition; i < crossPosition + 2; i++) {
                    var temp = population1.Questions[i];
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

        private List<QuestionPopulation> ChangeOperation(List<QuestionPopulation> populations, IEnumerable<Question> questions) {
            var r = new Random();

            foreach (QuestionPopulation population in populations) {
                var rIndex = r.Next(0, population.QuestionCount);
                var question = population.Questions[rIndex];

                var candidateQuestions = questions
                    .Where(q => q.Score == question.Score)
                    .Where(q => q.QuestionForm == question.QuestionForm);

                if (candidateQuestions.Any()) {
                    var rCandidateIndex = r.Next(0, candidateQuestions.Count());
                    population.Questions[rIndex] = questions.ElementAt(rCandidateIndex).ConvertToExaminationQuestion();
                }
            }

            return populations;
        }

        #endregion
    }
}