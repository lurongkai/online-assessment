using System;
using System.Collections.Generic;
using OnlineAssessment.Domain;
using OnlineAssessment.Domain.Service.ExaminationGeneration;

namespace OnlineAssessment.Service.Message
{
    public class ExaminationPaperConfig
    {
        public string SubjectKey { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public double Degree { get; set; }
        public int TotalScore { get; set; }

        public int SingleSelectionQuestionQuantity { get; set; }
        public int MutipleSelectionQuestionQuantity { get; set; }
        public int SubjectiveQuestionQuantity { get; set; }

        public double ExpectedAdaptationDegree { get; set; }

        internal PaperConstraint AsPaperConstraint() {
            var questionQuota = GetQuestionQuota();
            return new PaperConstraint(TotalScore, Degree, ExpectedAdaptationDegree, questionQuota);
        }

        private IDictionary<QuestionForm, int> GetQuestionQuota() {
            var quota = new Dictionary<QuestionForm, int>();

            quota.Add(QuestionForm.SingleSelection, SingleSelectionQuestionQuantity);
            quota.Add(QuestionForm.MultipleSelection, MutipleSelectionQuestionQuantity);
            quota.Add(QuestionForm.Subjective, SubjectiveQuestionQuantity);

            return quota;
        }
    }

    public class ExaminationConfig
    {
        public string Title { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }

        public bool BeginImmediately { get; set; }
    }
}