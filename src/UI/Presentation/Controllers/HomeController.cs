using System.Collections.Generic;
using System.Web.Mvc;
using MongoBlog.UI.Domain.Services;
using MongoBlog.UI.Domain.Entities;

namespace MongoBlog.UI.Presentation.Controllers {
    public class HomeController : ApplicationController {
        private IPostRepository _repository;


        public HomeController(IPostRepository repository) {
            _repository = repository;
        }

        public ActionResult Index() {
            IEnumerable<Post> posts = _repository.GetAll(SelectSpec.Default);
            return View(posts);
        }

    }
}