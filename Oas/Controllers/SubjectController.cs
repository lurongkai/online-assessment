﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oas.Domain;
using Oas.Models.Subject;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class SubjectController : Controller
    {
        private ICourseService _courseService;
        public SubjectController(ICourseService courseService) {
            _courseService = courseService;
        }

        public ActionResult Index(string courseId) {
            var subjects = _courseService.GetCourseSubjects(courseId);
            var pinnedSubjects = _courseService.GetCoursePinSubjects(courseId);
            var viewModel = new SubjectViewModel(subjects, pinnedSubjects);
            
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create(string courseId) {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string courseId, Subject subject) {
            _courseService.CreateSubject(courseId, subject);
            return RedirectToAction("Index");
        }

        public ActionResult PinSubject(string courseId, Guid subjectId) {
            _courseService.PinSubject(courseId, subjectId);
            return RedirectToAction("Index");
        }

        public ActionResult UnPinSubject(string courseId, Guid subjectId) {
            _courseService.UnPinSubject(courseId, subjectId);
            return RedirectToAction("Index");
        }
    }
}