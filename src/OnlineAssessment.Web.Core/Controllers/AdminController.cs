using System;
using System.Linq;
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
        private readonly IManagementService _managementService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ISubjectService _subjectService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ISubjectService subjectService,
                               IManagementService managementService,
                               UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager) {
            _subjectService = subjectService;
            _managementService = managementService;
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
            }
            catch {
                ViewBag.Message = "科目key已经存在";
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
            var teachers = _userManager.Users
                                       .Where(u => u.Roles.Any(r => r.RoleId == teacherRole.Id))
                                       .Select(u => new UserViewModel()
                                       {
                                           Name = u.Name,
                                           Username = u.UserName,
                                           RoleName = "Teacher",
                                           IsTeacher = true
                                       });
            var students = _userManager.Users
                                       .Where(u => u.Roles.Any(r => r.RoleId == studentRole.Id))
                                       .Select(u => new UserViewModel()
                                       {
                                           Name = u.Name,
                                           Username = u.UserName,
                                           RoleName = "Student",
                                           IsTeacher = false
                                       });
            viewModel.Users = teachers.Concat(students);
            //var teachers  = _userManager.Users.Where(u => u.Roles.Contains(teacherRole))

            return View(viewModel);
        }

        #endregion

        #region News

        public ActionResult NewsList(int? page) {
            var news = _managementService.GetAllNews(page);
            return View(news);
        }

        [HttpGet]
        public ActionResult NewsCreate() {
            return View();
        }

        [HttpPost]
        public ActionResult NewsCreate(News news) {
            news.PublishedDate = DateTime.Now;

            _managementService.CreateNews(news);
            return RedirectToAction("NewsList");
        }

        [HttpGet]
        public ActionResult NewsEdit(Guid newsId) {
            var news = _managementService.GetNews(newsId);
            return View(news);
        }

        [HttpPost]
        public ActionResult NewsEdit(News editedNews) {
            _managementService.EditNews(editedNews);
            return RedirectToAction("NewsList");
        }

        public ActionResult NewsDelete(Guid newsId) {
            _managementService.DeleteNews(newsId);
            return RedirectToAction("NewsList");
        }

        #endregion

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