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

using System;
using System.Security.Claims;
using System.Web.Mvc;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;
using OnlineAssessment.Web.Core.Models.Examination;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class ExaminationController : Controller
    {
        private readonly IAnsweringService _answeringService;
        private readonly IExaminationService _examinationService;

        public ExaminationController(IExaminationService examinationService, IAnsweringService answeringService) {
            _examinationService = examinationService;
            _answeringService = answeringService;
        }

        public ActionResult List(string subjectKey) {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;

            var examinations = _examinationService.GetStudentAvailableExaminations(userId, subjectKey);
            return View(examinations);
        }

        [HttpGet]
        public ActionResult Answering(string subjectKey, Guid examinationId) {
            var examination = _examinationService.GetExamination(examinationId);
            return View(examination);
        }

        [HttpPost]
        public ActionResult Answering(string subjectKey, Guid examinationId, AnswerSheet answerSheet) {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;

            _answeringService.UploadAnswerSheet(examinationId, userId, answerSheet);

            return RedirectToAction("List", new {subjectKey = subjectKey});
        }

        public ActionResult View(string subjectKey, Guid answerSheetId) {
            var answerSheet = _answeringService.GetAnswerSheet(answerSheetId);
            // TODO: do calculation.
            var viewModel = new ExaminationResultViewModel();
            return View(viewModel);
        }
    }
}