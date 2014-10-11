using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessment.Domain.Service.PaperGeneration
{
    public class PaperChromosome
    {
        private readonly double _expectedDegree;

        // 试卷期望难度系数
        public PaperChromosome(double expectedDegree) {
            _expectedDegree = expectedDegree;
            GeneSeries = new List<QuestionCharacter>();
        }

        public List<QuestionCharacter> GeneSeries { get; private set; }

        public int TotalScore {
            get {
                return GeneSeries.Count == 0
                    ? 0
                    : GeneSeries.Sum(q => q.QuestionScore);
            }
        }

        public double Degree {
            get {
                return GeneSeries.Count == 0
                    ? 0
                    : GeneSeries.Sum(q => q.QuestionScore*q.QuestionDegree)/TotalScore;
            }
        }

        public double Fitness {
            get {
                return GeneSeries.Count == 0
                    ? 0.00
                    : 1.00 - Math.Abs(Degree - _expectedDegree);
            }
        }

        public void ClearAllGenes() {
            GeneSeries.Clear();
        }

        public void AddGenes(IEnumerable<QuestionCharacter> questions) {
            GeneSeries.AddRange(questions);
        }
    }
}