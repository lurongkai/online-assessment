using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineAssessment.Domain
{
    public class Question : ICanMigrate
    {
        private double _questionDegree;

        public Question() {
            QuestionId = Guid.NewGuid();
            QuestionOptions = new List<QuestionOption>();
        }

        public Guid QuestionId { get; set; }

        [UIHint("QuestionForm")]
        public QuestionForm QuestionForm { get; set; }
        public QuestionCategory QuestionCategory { get; set; }
        public int Score { get; set; }

        [Required(ErrorMessage = "题目不能为空")]
        [Display(Name = "题目")]
        public string QuestionBody { get; set; }

        [Display(Name = "参考答案")]
        public string ReferenceRightAnswer { get; set; }

        public string subjectKey { get; set; }
        public virtual Subject Subject { get; set; }

        [Required]
        [UIHint("QuestionDegree")]
        [Display(Name = "难度")]
        public double QuestionDegree {
            get { return _questionDegree; }
            set {
                if (value < 0 || value > 1.0) {
                    throw new InvalidOperationException("invalid degree value. degree value should > 0 and < 1.0");
                }
                _questionDegree = value;
            }
        }

        public ICollection<QuestionOption> QuestionOptions { get; set; }

        public PaperQuestion ConvertToPaperQuestion()
        {
            var q = new PaperQuestion()
            {
                Score = Score,
                Degree = QuestionDegree,
                QuestionForm = QuestionForm,
                QuestionBody = QuestionBody,
                ReferenceRightAnswer = ReferenceRightAnswer
            };

            foreach (var questionOption in QuestionOptions)
            {
                q.QuestionOptions.Add(questionOption.ConvertToPaperQuestionOption());
            }

            return q;
        }
    }
}