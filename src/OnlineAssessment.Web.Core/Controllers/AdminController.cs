using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;
using OnlineAssessment.Web.Core.Models;

namespace OnlineAssessment.Web.Core.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ISubjectService _subjectService;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public AdminController(ISubjectService subjectService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) {
            _subjectService = subjectService;
            _userManager = userManager;
            _roleManager = roleManager;
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

        #region User

        public ActionResult UserList() {
            var viewModel = new UserManageViewModel();

            var teacherRole = _roleManager.FindByName("Teacher");
            var studentRole = _roleManager.FindByName("Student");

            //var teachers  = _userManager.Users.Where(u => u.Roles.Contains(teacherRole))

            return View(viewModel);
        }

        #endregion

        public ActionResult NewsList() {
            return View();
        }

        #region Teacher
        public ActionResult TeacherList() {
            var teachers = _roleManager.FindByName("Teacher").Users;
            return View(teachers);
        }

        public ActionResult TeacherCreate() {
            return View();
        }

        public ActionResult TeacherCreate(Teacher teacher, string password) {
            var teacherRole = _roleManager.FindByName("Teacher");
            _userManager.Create(teacher, password);
            return View();
        }

        #endregion

        #region Student
        public ActionResult StudentList() {
            var students = _roleManager.FindByName("Student").Users;
            return View(students);
        }
        #endregion
    }
}