using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Core.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ISubjectService _subjectService;
        private UserManager<ApplicationUser> _userManager;
        public AdminController(ISubjectService subjectService, UserManager<ApplicationUser> userManager) {
            _subjectService = subjectService;
            _userManager = userManager;
        }

        public ActionResult Dashboard() {
            return RedirectToAction("SubjectList");
        }

        #region Subject
        public ActionResult SubjectList() {
            var subjects = _subjectService.GetAllSubjects();
            return View(subjects);
        }
        [HttpGet]
        public ActionResult SubjectCreate() {
            return View();
        }
        [HttpPost]
        public ActionResult SubjectCreate(Subject subject) {
            try {
                _subjectService.AddSubject(subject);
                return RedirectToAction("SubjectList");
            } catch {
                ViewBag.Message = "输入有误";
                return View();
            }
        }
        [HttpGet]
        public ActionResult SubjectEdit(string subjectKey) {
            var subject = _subjectService.GetSubject(subjectKey);
            return View(subject);
        }
        [HttpPost]
        public ActionResult SubjectEdit(Subject editedSubject) {
            _subjectService.EditSubject(editedSubject);
            return RedirectToAction("SubjectList");
        }
        
        public ActionResult SubjectDelete(string subjectKey) {
            _subjectService.DeleteSubject(subjectKey);
            return RedirectToAction("SubjectList");
        }

        #endregion

        public ActionResult NewsList() {
            return View();
        }

        public ActionResult TeacherList() {
            return View();
        }

        public ActionResult StudentList() {
            return View();
        }
    }
}