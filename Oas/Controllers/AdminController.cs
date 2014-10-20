using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Oas.Domain;
using Oas.Membership;
using Oas.Models.Admin;
using Oas.Service.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Oas.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IManagementService _managementService;
        private readonly ICourseService _courseService;
        private readonly OasUserManager _userManager;

        public AdminController(ICourseService courseService,
                               IManagementService managementService,
                               OasUserManager userManager) {
            _courseService = courseService;
            _managementService = managementService;
            _userManager = userManager;
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult PublishNews() {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult CreateTeacher() {
            var courses = new List<Course>() {new Course(){CourseId = "A", CourseName = "AA"}, new Course(){CourseId = "B", CourseName = "BB"}};
            //var courses = _courseService.GetAllCourses();
            ViewBag.Courses = new SelectList(courses, "CourseId", "CourseName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateTeacher(CreateTeacherViewModel teacherViewModel) {
            if (ModelState.IsValid) {
                var teacher = new OasIdentityUser(teacherViewModel.Username);
                var result = await _userManager.CreateAsync(teacher, teacherViewModel.Password);
                if (result.Succeeded) {
                    _userManager.AddToRole(teacher.Id, "Teacher");
                    _managementService.CreateTeacher(new Teacher() { MemberId = new Guid(teacher.Id) });
                    _managementService.AssigningCourse(new Guid(teacher.Id), teacherViewModel.CourseId);
                    return RedirectToAction("Index");
                }

                AddErrors(result);
            }

            return View(teacherViewModel);
        }

        public ActionResult CreateCourse() {
            throw new NotImplementedException();
        }

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) { ModelState.AddModelError("", error); }
        }
    }
}