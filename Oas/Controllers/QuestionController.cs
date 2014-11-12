using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Oas.Domain;
using Oas.Models.Question;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class QuestionController : Controller
    {
        private IQuestionService _questionService;
        private ICourseService _courseService;

        public QuestionController(IQuestionService questionService, ICourseService courseService) {
            _questionService = questionService;
            _courseService = courseService;
        }

        public ActionResult Index(string courseId) {
            var subjects = _courseService.GetCourseSubjects(courseId);
            return View(subjects);
        }

        public ActionResult List(string courseId, Guid subjectId) {
            var selectableQuestions = _questionService.GetAllSelectableQuestion(courseId, subjectId);
            var subjectiveQuestions = _questionService.GetAllSubjectiveQuestion(courseId, subjectId);
            var viewModel = new QuestionViewModel(selectableQuestions, subjectiveQuestions);

            ViewBag.SubjectId = subjectId;
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("CreateSelectable")]
        public ActionResult Create(string courseId, Guid subjectId, SelectableQuestion question) {
            _questionService.CreateSelectableQuestion(subjectId, question);
            return RedirectToAction("List", new {subjectId});
        }

        [HttpPost]
        [ActionName("CreateSubjective")]
        public ActionResult Create(string courseId, Guid subjectId, SubjectiveQuestion question, HttpPostedFileBase attachment) {
            if (attachment != null) {
                var basePath = Path.Combine(Server.MapPath("~"), "questionAttachments");
                if (!Directory.Exists(basePath)) {
                    Directory.CreateDirectory(basePath);
                }

                var fileName = attachment.FileName;
                var extension = Path.GetExtension(fileName);
                var targetPath = Path.Combine(basePath, Guid.NewGuid() + extension);
                attachment.SaveAs(targetPath);

                question.AttachmentName = fileName;
                question.AttachmentPath = targetPath;
            }
            _questionService.CreateSubjectiveQuestion(subjectId, question);
            return RedirectToAction("List", new {subjectId});
        }

        public ActionResult Delete(string courseId, Guid subjectId, Guid questionId) {
            _questionService.DeleteQuestion(questionId);
            return RedirectToAction("List", new {subjectId});
        }
    }
}