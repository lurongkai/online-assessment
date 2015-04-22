using System;
using System.Collections.Generic;
using System.Linq;
using Oas.Domain;

namespace Oas.Models.Record
{
    public class AnswerSheetDetailViewModel
    {
        public AnswerSheetDetailViewModel(AnswerSheet answerSheet)
        {
            SingleSelectableQuestions = new List<SelectableDetail>();
            MultipleSelectableQuestions = new List<SelectableDetail>();
            SubjectiveQuestions = new List<SubjectiveDetail>();

            InitSelfWithAnswerSheet(answerSheet);
        }

        public List<SelectableDetail> SingleSelectableQuestions { get; set; }
        public List<SelectableDetail> MultipleSelectableQuestions { get; set; }
        public List<SubjectiveDetail> SubjectiveQuestions { get; set; }

        private void InitSelfWithAnswerSheet(AnswerSheet answerSheet)
        {
            InitSelectableQuestionAnswers(answerSheet);

            InitSubjectiveQuestionAnswers(answerSheet);
        }

        private void InitSelectableQuestionAnswers(AnswerSheet answerSheet)
        {
            foreach (var question in answerSheet.SelectableQuestionAnswers)
            {
                var detail = new SelectableDetail
                {
                    Body = question.Question.Body,
                    Score = question.Question.Score,
                    GotScore = question.GotScore,
                    Options = ParseSelectableQuestionOptions(question)
                };

                if (question.IsSingle)
                {
                    SingleSelectableQuestions.Add(detail);
                }
                else
                {
                    MultipleSelectableQuestions.Add(detail);
                }
            }
        }

        private void InitSubjectiveQuestionAnswers(AnswerSheet answerSheet)
        {
            foreach (var question in answerSheet.SubjectiveQuestionAnswers)
            {
                var detail = new SubjectiveDetail
                {
                    Body = question.Question.Body,
                    Answer = question.Question.Answer,
                    Score = question.Question.Score,
                    WriteDown = question.WriteDown,
                    GotScore = question.GotScore
                };
                SubjectiveQuestions.Add(detail);
            }
        }

        private List<SelectableOption> ParseSelectableQuestionOptions(SelectableQuestionItem question)
        {
            var options = question.Question.Options.ToList();

            var checkedOptions = question.CheckedOptions.ToList();

            return (from option in options
                let optionChecked = checkedOptions.Any(o => o.OptionId == option.OptionId)
                select new SelectableOption
                {
                    Content = option.Content,
                    Checked = optionChecked,
                    ChoiceIsRight = optionChecked && option.IsRight
                }).ToList();
        }
    }

    public class SelectableDetail
    {
        public SelectableDetail()
        {
            Options = new List<SelectableOption>();
        }

        public string Body { get; set; }
        public int Score { get; set; }
        public int GotScore { get; set; }
        public List<SelectableOption> Options { get; set; }
    }

    public class SelectableOption
    {
        public string Content { get; set; }
        public bool Checked { get; set; }
        public bool ChoiceIsRight { get; set; }
    }

    public class SubjectiveDetail
    {
        public string Body { get; set; }
        public string Answer { get; set; }
        public string WriteDown { get; set; }
        public int Score { get; set; }
        public int GotScore { get; set; }
    }
}