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
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Core.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService) {
            _questionService = questionService;
        }

        public ActionResult List(string subjectKey, int? page) {
            ViewBag.subjectKey = subjectKey;
            ViewBag.Page = page ?? 1;
            var questions = _questionService.GetAllQuestion(subjectKey, page);

            return View(questions);
        }

        [HttpGet]
        public ActionResult Create(string subjectKey, QuestionForm questionForm) {
            ViewBag.subjectKey = subjectKey;
            ViewBag.questionForm = questionForm;

            ViewBag.QuestionCategory = new List<SelectListItem>
            {
                new SelectListItem {Value = "Theory", Text = "理论模块"},
                new SelectListItem {Value = "Skill", Text = "技能模块"},
                new SelectListItem {Value = "SkillExtension", Text = "拓展技能模块"}
            };
            ViewBag.QuestionDegree = new List<SelectListItem>
            {
                new SelectListItem {Value = "0.1", Text = "0.1"},
                new SelectListItem {Value = "0.2", Text = "0.2"},
                new SelectListItem {Value = "0.3", Text = "0.3"},
                new SelectListItem {Value = "0.4", Text = "0.4"},
                new SelectListItem {Value = "0.5", Text = "0.5"},
                new SelectListItem {Value = "0.6", Text = "0.6"},
                new SelectListItem {Value = "0.7", Text = "0.7"},
                new SelectListItem {Value = "0.8", Text = "0.8"},
                new SelectListItem {Value = "0.9", Text = "0.9"}
            };

            var question = new Question();
            if (questionForm != QuestionForm.Subjective) {
                question.QuestionOptions.Add(new QuestionOption()
                {
                    IsRightAnswer = true,
                    Description = "Default"
                });
            }
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string subjectKey, Question newQuestion) {
            if (newQuestion.QuestionForm == QuestionForm.SingleSelection) { newQuestion.Score = 2; }
            if (newQuestion.QuestionForm == QuestionForm.MultipleSelection) { newQuestion.Score = 3; }
            if (newQuestion.QuestionForm == QuestionForm.Subjective) {
                newQuestion.Score = newQuestion.QuestionDegree > 0.3
                    ? (int) Math.Floor(newQuestion.QuestionDegree*10)
                    : 3;
            }

            _questionService.AddQuestion(subjectKey, newQuestion);
            return RedirectToAction("List", new {subjectKey});
        }

        [HttpGet]
        public ActionResult Delete(string subjectKey, Guid questionId) {
            _questionService.DeleteQuestion(questionId);
            return RedirectToAction("List", new {subjectKey});
        }

        [HttpGet]
        public ActionResult Edit(string subjectKey, Guid questionId) {
            var question = _questionService.GetQuestion(questionId);
            return View(question);
        }

        [HttpPost]
        public ActionResult Edit(string subjectKey, Question editedQuestion) {
            _questionService.ModifyQuestion(editedQuestion);
            return RedirectToAction("List", new {subjectKey});
        }
    }
}