using System.Web.Mvc;
using MongoBlog.UI.Domain.Entities;
using MongoBlog.UI.Domain.Services;
using MongoBlog.UI.Presentation.ViewModels;
using System.Web.Security;

namespace MongoBlog.UI.Presentation.Controllers {
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
    }
}