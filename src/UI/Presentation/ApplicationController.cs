using System.Web.Mvc;
using Cosmicvent.FluentAuthentication;
using MongoBlog.Web.DependencyResolution;
using MongoBlog.Web.Domain.Entities;
using MongoBlog.Web.Domain.Services;

namespace MongoBlog.Web.Presentation {
    public abstract class ApplicationController : Controller {
        private User _currentUser;

        protected User CurrentUser {
            get {
                if (_currentUser != null) {
                    return _currentUser;
                }

                var session = ServiceLocator.GetInstance<IUserSession>();
                _currentUser = session.GetCurrentUser();
                return _currentUser;
            }
        }

        protected override void OnAuthorization(AuthorizationContext filterContext) {
            var settings = ServiceLocator.GetInstance<IAuthenticationSettings>();

            string action = RouteData.GetRequiredString("action");
            string controller = RouteData.GetRequiredString("controller");

            bool allowed = false;

            if (settings.HasAnonymousAccess(controller, action)) {
                base.OnAuthorization(filterContext);
                return;
            }

            if (!User.Identity.IsAuthenticated) {
                AddError("Please login to access this page");
                filterContext.Result = RedirectToAction("LogOn", "Accounts");
                return;
            }

            if (!settings.HasAccess(controller, action, CurrentUser.Role)) {
                //add error and redirect
                AddError("You don't have access to this page, please contact your administrator");
                filterContext.Result = RedirectToAction("Index", "Posts");
                return;
            }
            base.OnAuthorization(filterContext);
        }

        private void AddError(string error) {
            TempData["error"] = error;
        }
    }
}