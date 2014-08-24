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
using System.Web.Mvc;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;
using OnlineAssessment.Service.Message;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class ExaminationManageController : Controller
    {
        private readonly IExaminationService _examinationService;

        public ExaminationManageController(IExaminationService examinationService) {
            _examinationService = examinationService;
        }

        public ActionResult List(string subjectKey, ExaminationState state = ExaminationState.Active) {
            var examinations = _examinationService.GetAllExaminations(subjectKey, state);
            return View(examinations);
        }

        [HttpGet]
        public ActionResult Create(string subjectKey, Guid paperId) {
            ViewBag.paperId = paperId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(string subjectKey, Guid paperId, ExaminationConfig config) {
            _examinationService.AddExamination(subjectKey, paperId, config);
            return RedirectToAction("List", new {subjectKey = subjectKey});
        }

        public ActionResult Active(string subjectKey, Guid examinationId) {
            _examinationService.ActiveExamination(examinationId);
            return RedirectToAction("List", new {subjectKey = subjectKey});
        }

        public ActionResult Archive(string subjectKey, Guid examinationId) {
            _examinationService.ArchiveExamination(examinationId);
            return RedirectToAction("List", new {subjectKey = subjectKey});
        }
    }
}