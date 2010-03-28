using System.Web.Mvc;
using System.Web.Security;
using MongoBlog.Web.Domain.Entities;
using MongoBlog.Web.Domain.Services;
using MongoBlog.Web.Presentation.ViewModels;

namespace MongoBlog.Web.Presentation.Controllers {
    public class AccountsController : ApplicationController {
        private readonly IUserRepository _repository;

        public AccountsController(IUserRepository repository) {
            _repository = repository;
        }

        public ActionResult LogOn() {
            return View(new LogonForm());
        }

        [HttpPost]
        public ActionResult LogOn(LogonForm form) {
            User user = _repository.GetByUserName(form.UserName);
            if (user == null || !user.Password.Equals(form.Password)) {
                TempData["error"] = "Invalid username or password";
                return RedirectToAction("LogOn");
            }

            FormsAuthentication.RedirectFromLoginPage(form.UserName, false);
            return RedirectToAction("Index", "Posts");
        }

        public ActionResult LogOff() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Posts");
        }
    }
}