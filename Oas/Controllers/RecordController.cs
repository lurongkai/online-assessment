using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    public class RecordController : Controller
    {
        private readonly IExamService _examService;

        public RecordController(IExamService examService)
        {
            _examService = examService;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var myAnswerSheets = _examService.GetStudentAnswerSheets(new Guid(userId))
                .OrderBy(sas => sas.Timestamp);
            return View(myAnswerSheets);
        }

        public ActionResult Detail(Guid answerSheetId)
        {
            throw new NotImplementedException();
        }
    }
}