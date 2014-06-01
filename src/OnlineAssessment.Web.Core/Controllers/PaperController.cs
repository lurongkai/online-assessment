using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAssessment.Service.Message;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class PaperController : Controller
    {
        public ActionResult List(Guid subjectId)
        {
            return View();
        }

        public ActionResult Create(Guid subjectId, ExaminationPaperConfig config) {
            throw new NotImplementedException();
        }

        public ActionResult View(Guid subjectId, Guid paperId) {
            throw new NotImplementedException();
        }
    }
}