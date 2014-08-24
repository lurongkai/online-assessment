// Author:
//      Lu Rongkai <lurongkai@gmail.com>
// 
// Copyright (c) 2014 lurongkai
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
// 
// Source code hosted on: https://github.com/lurongkai/online-assessment

using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManagementService _managementService;

        public HomeController(IManagementService managementService) {
            _managementService = managementService;
        }

        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) {
                var news = _managementService.GetAllNews(1, 3);
                ViewBag.News = news;
                return View();
            }

            if (User.IsInRole("Admin")) { return RedirectToAction("Dashboard", "Admin"); }

            return RedirectToAction("ChoiceSubject");
        }

        public ActionResult News(Guid newsId) {
            var news = _managementService.GetNews(newsId);
            return View(news);
        }

        [Authorize]
        public ActionResult ChoiceSubject() {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;
            if (User.IsInRole("Teacher")) {
                var subject = _managementService.GetTeacherSubject(userId);
                return RedirectToAction("Dashboard", new {subjectKey = subject.SubjectKey});
            }

            if (User.IsInRole("Student")) {
                var subjects = _managementService.GetStudentSubjects(userId);

                if (subjects.Count() == 1) { return RedirectToAction("Dashboard", new {subjectKey = subjects.First().SubjectKey}); }
                return View(subjects);
            }

            return View(Enumerable.Empty<Subject>());
        }

        [Authorize(Roles = "Student, Teacher, Admin")]
        public ActionResult Dashboard() {
            return View();
        }

        [ChildActionOnly]
        public ActionResult StudentMenu() {
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