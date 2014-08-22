using System;
using System.Security.Claims;
using System.Web.Mvc;
using OnlineAssessment.Service;
using System.Collections.Generic;
using OnlineAssessment.Domain;
using System.Linq;
using OnlineAssessment.Web.Core.Models;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManagementService _managementService;

        public HomeController(IManagementService managementService) {
            _managementService = managementService;
        }

        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated)
            {
                var news = _managementService.GetAllNews(1, 3);
                ViewBag.News = news;
                return View();
            }

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            return RedirectToAction("ChoiceSubject");
        }

        public ActionResult News(Guid newsId)
        {
            var news = _managementService.GetNews(newsId);
            return View(news);
        }

        [Authorize]
        public ActionResult ChoiceSubject() {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;
            if (User.IsInRole("Teacher"))
            {
                var subject = _managementService.GetTeacherSubject(userId);
                return RedirectToAction("Dashboard", new {subjectKey = subject.SubjectKey});
            }

            if (User.IsInRole("Student"))
            {
                var subjects = _managementService.GetStudentSubjects(userId);

                if (subjects.Count() == 1) {
                    return RedirectToAction("Dashboard", new { subjectKey = subjects.First().SubjectKey });
                }
                return View(subjects);
            }

            return View(Enumerable.Empty<Subject>());
        }

        [Authorize(Roles = "Student, Teacher, Admin")]
        public ActionResult Dashboard() {
            return View();
        }

        [ChildActionOnly]
        public ActionResult StudentMenu()
        {
            return PartialView("_studentMenu");
        }

        [ChildActionOnly]
        public ActionResult TeacherMenu() {
            return PartialView("_teacherMenu");
        }

        [ChildActionOnly]
        public ActionResult AdminMenu() {
            return PartialView("_adminMenu");
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult Contact() {
            return View();
        }
    }
}