using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessment.Domain.Service.ExaminationGeneration
{
    internal class QuestionPopulation
    {
        private readonly PaperConstraint _paperConstraint;

        public QuestionPopulation(PaperConstraint paperConstraint) {
            _paperConstraint = paperConstraint;

            Questions = new List<PaperQuestion>();
        }

        public List<PaperQuestion> Questions { get; set; }

        public int TotalScore {
            get { return Questions.Sum(q => q.Score); }
        }

        public double Degree {
            get { return Questions.Sum(q => q.AvarageDegreeFactor) / TotalScore; }
        }

        public double AdaptationDegree {
            get {
                return Questions.Count == 0
                    ? 0.00
                    : 1 - Math.Abs(_paperConstraint.Degree - Degree);
            }
        }

        internal int QuestionCount {
            get { return Questions.Count; }
        }

        internal void ClearAllQuestions() {
            Questions.Clear();
        }
    }
}