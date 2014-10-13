using System;
using System.Web.Mvc;
using Oas.Membership;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IManagementService _managementService;
        private readonly OasRoleManager _roleManager;
        private readonly ICourseService _subjectService;
        private readonly OasUserManager _userManager;

        public AdminController(ICourseService subjectService,
                               IManagementService managementService,
                               OasUserManager userManager,
                               OasRoleManager roleManager) {
            _subjectService = subjectService;
            _managementService = managementService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public ActionResult PublishNews() {
            throw new NotImplementedException();
        }

        public ActionResult CreateTeacher() {
            throw new NotImplementedException();
        }
    }
}