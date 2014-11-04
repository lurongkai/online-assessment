using System;
using System.Collections.Generic;
using System.Linq;

namespace Oas.Models.Simulation
{
    public class SimulationInspectViewModel
    {
        private Domain.Service.Paper paper;
        private SimulationInputModel model;

        public SimulationInspectViewModel(Domain.Service.Paper paper, SimulationInputModel model) {
            SingleQuestions = new List<SingleQuestionInspect>();
            MultipleQuestions = new List<MultipleQuestionInspect>();
            SubjectiveQuestions = new List<SubjectiveQuestionInspect>();

            foreach (var q in paper.SingleQuestions) {
                var a = model.SingleQuestions.FirstOrDefault(s => s.QuestionId == q.QuestionId);
                var single = new SingleQuestionInspect
                {
                    QuestionId = q.QuestionId,
                    Body = q.Body,
                    Score = q.Score,
                    Options = q.Options.Select(o => new QuestionOptionInspect
                    {
                        OptionId = o.OptionId, IsRight = o.IsRight, Content = o.Content
                    }).ToList()
                };

                if (a != null && a.CheckedOption.HasValue) {
                    var checkedOption = single.Options.FirstOrDefault(o => o.OptionId == a.CheckedOption.Value);
                    if (checkedOption != null) {
                        checkedOption.Checked = true;
                    }
                }
                SingleQuestions.Add(single);
            }
            foreach (var q in paper.MultipleQuestions) {
                var a = model.MultipleQuestions.FirstOrDefault(s => s.QuestionId == q.QuestionId);
                var multiple = new MultipleQuestionInspect
                {
                    QuestionId = q.QuestionId,
                    Body = q.Body,
                    Score = q.Score,
                    Options = q.Options.Select(o => new QuestionOptionInspect
                    {
                        OptionId = o.OptionId, IsRight = o.IsRight, Content = o.Content
                    }).ToList()
                };

                if (a != null) {
                    foreach (var co in a.CheckedOptions) {
                        var checkedOption = multiple.Options.FirstOrDefault(o => o.OptionId == co.OptionId);
                        if (checkedOption != null) {
                            checkedOption.Checked = co.Checked;
                        }
                    }
                }
                MultipleQuestions.Add(multiple);
            }
            foreach (var q in paper.SubjectiveQuestions) {
                var a = model.SubjectiveQuestions.FirstOrDefault(s => s.QuestionId == q.QuestionId);
                var subjective = new SubjectiveQuestionInspect
                {
                    QuestionId = q.QuestionId,
                    Body = q.Body,
                    Score = q.Score,
                    Answer = q.Answer
                };
                if (a != null) {
                    subjective.WriteDown = a.WriteDown;
                }

                SubjectiveQuestions.Add(subjective);
            }
        }

        public List<SingleQuestionInspect> SingleQuestions { get; set; }
        public List<MultipleQuestionInspect> MultipleQuestions { get; set; }
        public List<SubjectiveQuestionInspect> SubjectiveQuestions { get; set; }
    }

    public class SingleQuestionInspect
    {
        public Guid QuestionId { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
        public List<QuestionOptionInspect> Options { get; set; }
    }

    public class MultipleQuestionInspect
    {
        public Guid QuestionId { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
        public List<QuestionOptionInspect> Options { get; set; }
    }

    public class QuestionOptionInspect
    {
        public Guid OptionId { get; set; }
        public string Content { get; set; }
        public bool Checked { get; set; }
        public bool IsRight { get; set; }
    }

    public class SubjectiveQuestionInspect
    {
        public Guid QuestionId { get; set; }
        public string Answer { get; set; }
        public string WriteDown { get; set; }

        public int Score { get; set; }
        public string Body { get; set; }
    }
}