using System.Web.Mvc;
namespace MongoBlog.UI.Presentation.Controllers {
    public class HomeController : ApplicationController {

        public HomeController() {

        }

        public ActionResult Index() {
            return View();
        }

    }

    public class ApplicationController : Controller {
    }
}