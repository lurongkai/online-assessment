using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Oas.Membership;
using Oas.Models;

namespace Oas.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private OasUserManager _userManager;

        public AccountController(OasUserManager userManager) {
            _userManager = userManager;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl) {
            if (ModelState.IsValid) {
                var user = await _userManager.FindAsync(model.UserName, model.Password);
                if (user != null) {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model) {
            if (ModelState.IsValid) {
                var user = new OasIdentity {UserName = model.UserName};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            return View(model);
        }

        public ActionResult Manage() {
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model) {
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (ModelState.IsValid) {
                var result =
                    await _userManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                if (result.Succeeded) { return RedirectToAction("Manage"); }
                AddErrors(result);
            }

            return View(model);
        }

        public ActionResult LogOff() {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing) {
            if (disposing && _userManager != null) {
                _userManager.Dispose();
                _userManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager AuthenticationManager {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        private async Task SignInAsync(OasIdentity user, bool isPersistent) {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties {IsPersistent = isPersistent}, identity);
        }

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) { ModelState.AddModelError("", error); }
        }

        private ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) { return Redirect(returnUrl); }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}