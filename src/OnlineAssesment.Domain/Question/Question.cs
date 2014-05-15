using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Domain
{
    public class Question : ICanMigrate
    {
        public Question() {
            QuestionId = Guid.NewGuid();
            QuestionOptions = new List<QuestionOption>();
        }

        public Guid QuestionId { get; set; }

        public QuestionType QuestionType { get; set; }
        public QuestionSubject QuestionSubject { get; set; }

        [Required(ErrorMessage="题目不能为空")]
        [Display(Name="题目")]
        public string QuestionBody { get; set; }

        [Required(ErrorMessage = "参考答案不能为空")]
        [Display(Name = "参考答案")]
        public string ReferenceRightAnswer { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        private float _questionDegree;
        [Required]
        [Display(Name = "难度")]
        public float QuestionDegree {
            get { return _questionDegree; }
            set {
                if (value < 0 || value > 1.0) {
                    throw new InvalidOperationException("invalid degree value. degree value should > 0 and < 10");
                }
                _questionDegree = value;
            }
        }

        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }

        //public string GetChapterTitle() {
        //    return Chapter == null ? String.Empty : Chapter.Title;
        //}
    }
}
