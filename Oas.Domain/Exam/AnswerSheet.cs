using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Domain
{
    public class AnswerSheet
    {
        public AnswerSheet()
        {
            AnswerSheetId = Guid.NewGuid();
            SelectableQuestionAnswers = new List<SelectableQuestionItem>();
            SubjectiveQuestionAnswers = new List<SubjectiveQuestionItem>();
        }

        public Guid AnswerSheetId { get; set; }
        public bool IsEnvaluated { get; set; }
        public int TotalScore { get; set; }
        public DateTime Timestamp { get; set; }

        public List<SelectableQuestionItem> SelectableQuestionAnswers { get; set; }
        public List<SubjectiveQuestionItem> SubjectiveQuestionAnswers { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

        public void PreEvaluate()
        {
            if (IsEnvaluated)
            {
                return;
            }

            foreach (var selectableQuestionAnswer in SelectableQuestionAnswers)
            {
                selectableQuestionAnswer.Evaluate();
            }

            TotalScore = SelectableQuestionAnswers.Sum(sqa => sqa.GotScore);
        }

        public void Evaluate()
        {
            TotalScore = SelectableQuestionAnswers.Sum(sqa => sqa.GotScore) +
                         SubjectiveQuestionAnswers.Sum(sqa => sqa.GotScore);
            IsEnvaluated = true;
        }
    }
    
    public class SelectableQuestionItem
    {
        public SelectableQuestionItem()
        {
            SelectableQuestionItemId = Guid.NewGuid();
            CheckedOptions = new List<QuestionItemOption>();
        }

        public Guid SelectableQuestionItemId { get; set; }
        public int GotScore { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsSingle { get; set; }
        public virtual SelectableQuestion Question { get; set; }
        public virtual ICollection<QuestionItemOption> CheckedOptions { get; set; }

        public void Evaluate()
        {
            if (CheckedOptions.Count == 0)
            {
                return;
            }

            if (IsSingle)
            {
                var onlyOptionId = CheckedOptions.ElementAt(0).OptionId;
                if (onlyOptionId == null)
                {
                    return;
                }

                var optionId = onlyOptionId.Value;
                var rightOption = Question.Options.SingleOrDefault(o => o.IsRight);
                if (rightOption != null && rightOption.OptionId == optionId)
                {
                    GotScore = Question.Score;
                }
            }
            else
            {
                var checkedOptionIds = CheckedOptions.Where(co => co.OptionId != null).ToList().Select(co => co.OptionId.Value);
                var rightOptionIds = Question.Options.Where(co => co.IsRight).Select(co => co.OptionId).ToList();

                var isAllRight = checkedOptionIds.All(checkedOptionId => rightOptionIds.Contains(checkedOptionId));

                GotScore = isAllRight ? Question.Score : 0;
            }
        }
    }

    public class QuestionItemOption
    {
        public QuestionItemOption()
        {
            QuestionItemOptionId = Guid.NewGuid();
        }
        public Guid QuestionItemOptionId { get; set; }
        public Guid? OptionId { get; set; }
    }

    public class SubjectiveQuestionItem
    {
        public SubjectiveQuestionItem()
        {
            SubjectiveQuestionItemId = Guid.NewGuid();
        }
        public Guid SubjectiveQuestionItemId { get; set; }
        public string WriteDown { get; set; }
        public int GotScore { get; set; }
        public Guid QuestionId { get; set; }
        public virtual SubjectiveQuestion Question { get; set; }
    }
}
