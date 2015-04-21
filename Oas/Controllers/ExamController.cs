using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Oas.Domain;
using Oas.Domain.Service;
using Oas.Models.Exam;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    public class ExamController : Controller
    {
        private const string Paper = "CurrentPaper";
        private IExamService _examService;
        private IQuestionService _questionService;

        public ExamController(IExamService examService, IQuestionService questionService) {
            _examService = examService;
            _questionService = questionService;
        }

        public ActionResult Index(string courseId) {
            return View();
        }

        public ActionResult StartNew(string courseId, string style) {
            var paper = _examService.GeneratePaper(courseId, style);
            return View(paper);
        }

        public ActionResult Submit(string courseId, ExamInputModel model) {
            var paper = (Paper) Session[Paper];
            var answerSheet = ConvertToAnswerSheet(model);

            var userId = User.Identity.GetUserId();
            var answerSheetId = _examService.UploadAnswerSheet(courseId, new Guid(userId), answerSheet);

            _examService.PreEvaluation(answerSheetId);
            TempData["SlashMessage"] = "提交成功，请等待老师为主观题打分";

            return RedirectToAction("Index", "Record");
        }

        public ActionResult Inspect(string courseId) {
            var viewModel = (ExamInspectViewModel) TempData["Inspect"];
            return View(viewModel);
        }

        public ActionResult DownloadAttachment(Guid questionId) {
            var question = _questionService.GetSubjectiveQuestion(questionId);
            return File(question.AttachmentPath, @"application/octet-stream", question.AttachmentName);
        }

        private AnswerSheet ConvertToAnswerSheet(ExamInputModel model)
        {
            var answerSheet = new AnswerSheet();

            foreach (var singleQuestion in model.SingleQuestions)
            {
                var item = new SelectableQuestionItem();
                item.QuestionId = singleQuestion.QuestionId;
                item.IsSingle = true;
                item.CheckedOptions.Add(new QuestionItemOption
                {
                    OptionId = singleQuestion.CheckedOption
                });
                answerSheet.SelectableQuestionAnswers.Add(item);
            }

            foreach (var multipleQuestion in model.MultipleQuestions)
            {
                var item = new SelectableQuestionItem();
                item.QuestionId = multipleQuestion.QuestionId;
                item.IsSingle = false;
                foreach (var option in multipleQuestion.CheckedOptions)
                {
                    item.CheckedOptions.Add(new QuestionItemOption
                    {
                        OptionId = option.OptionId
                    });
                }
                answerSheet.SelectableQuestionAnswers.Add(item);
            }

            foreach (var subjectQuestion in model.SubjectiveQuestions)
            {
                var item = new SubjectiveQuestionItem();
                item.QuestionId = subjectQuestion.QuestionId;
                item.WriteDown = subjectQuestion.WriteDown;
                answerSheet.SubjectiveQuestionAnswers.Add(item);
            }

            return answerSheet;
        }
    }
}