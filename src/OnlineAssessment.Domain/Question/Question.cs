using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineAssessment.Domain
{
    public class Question : ICanMigrate
    {
        private float _questionDegree;

        public Question()
        {
            QuestionId = Guid.NewGuid();
            QuestionOptions = new List<QuestionOption>();
        }

        public Guid QuestionId { get; set; }

        public QuestionForm QuestionForm { get; set; }
        public QuestionCategory QuestionSubject { get; set; }
        public int Score { get; set; }

        [Required(ErrorMessage = "题目不能为空")]
        [Display(Name = "题目")]
        public string QuestionBody { get; set; }

        [Required(ErrorMessage = "参考答案不能为空")]
        [Display(Name = "参考答案")]
        public string ReferenceRightAnswer { get; set; }

        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [Required]
        [Display(Name = "难度")]
        public float QuestionDegree
        {
            get { return _questionDegree; }
            set
            {
                if (value < 0 || value > 1.0)
                {
                    throw new InvalidOperationException("invalid degree value. degree value should > 0 and < 1.0");
                }
                _questionDegree = value;
            }
        }

        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }

        public PaperQuestion ConvertToExaminationQuestion()
        {
            throw new NotImplementedException();
        }
    }
}