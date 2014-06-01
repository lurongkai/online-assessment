using System;
using System.Web.Mvc;
using OnlineAssessment.Service;
using System.Collections.Generic;
using OnlineAssessment.Domain;
using System.Linq;

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
        public ActionResult ChoiceSubject()
        {
            if (User.IsInRole("Teacher"))
            {
                var subject = _membershipService.GetTeacherSubject(Session["UserId"].ToString());
                return RedirectToAction("Dashboard", new {subjectId = subject.SubjectId});
            }

            if (User.IsInRole("Student"))
            {
                var subjects = _membershipService.GetStudentSubjects(Session["UserId"].ToString());

                if (subjects.Count() == 1) {
                    return RedirectToAction("Dashboard", new { subjectId = subjects.First().SubjectId });
                }
            }

            return View(Enumerable.Empty<Subject>());
        }

        [Authorize(Roles = "Student, Teacher, Admin")]
        public ActionResult Dashboard() {
			// var userId = (string) Session["UserId"];
			// var profile = _membershipService.GetProfile(userId);
			// ViewBag.Profile = profile;

            return View();
        }

        [ChildActionOnly]
        public ActionResult TeacherSubjects()
        {
            return PartialView();
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult Contact() {
            return View();
        }
    }
}