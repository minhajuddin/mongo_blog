using System.Web.Mvc;
using MongoBlog.UI.DependencyResolution;
using Cosmicvent.FluentAuthentication;
using MongoBlog.UI.Domain.Entities;
using MongoBlog.UI.Domain.Services;

namespace MongoBlog.UI.Presentation {
    public abstract class ApplicationController : Controller {

        User _currentUser;

        protected override void OnAuthorization(AuthorizationContext filterContext) {
            IAuthenticationSettings settings = ServiceLocator.GetInstance<IAuthenticationSettings>();

            var action = RouteData.GetRequiredString("action");
            var controller = RouteData.GetRequiredString("controller");

            bool allowed = false;

            if (settings.HasAnonymousAccess(controller, action)) {
                base.OnAuthorization(filterContext);
                return;
            }

            if (!User.Identity.IsAuthenticated) {
                AddError("Please login to access this page");
                filterContext.Result = RedirectToAction("LogOn", "Accounts");
            }

            if (!settings.HasAccess(controller, action, CurrentUser.Role)) {
                //add error and redirect
                AddError("You don't have access to this page, please contact your administrator");
                filterContext.Result = RedirectToAction("Index", "Posts");
            }
            base.OnAuthorization(filterContext);
        }

        private void AddError(string error) {
            TempData["error"] = error;
        }

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
    }
}