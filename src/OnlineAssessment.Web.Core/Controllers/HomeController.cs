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
        private readonly IMembershipService _membershipService;

        public HomeController(IMembershipService membershipService) {
            _membershipService = membershipService;
        }

        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) {
                return View();
            }

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            return RedirectToAction("ChoiceSubject");
        }

        [Authorize]
        public ActionResult ChoiceSubject() {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;
            if (User.IsInRole("Teacher"))
            {
                var subject = _membershipService.GetTeacherSubject(userId);
                return RedirectToAction("Dashboard", new {subjectId = subject.SubjectId});
            }

            if (User.IsInRole("Student"))
            {
                var subjects = _membershipService.GetStudentSubjects(userId);

                if (subjects.Count() == 1) {
                    return RedirectToAction("Dashboard", new { subjectId = subjects.First().SubjectId });
                }
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