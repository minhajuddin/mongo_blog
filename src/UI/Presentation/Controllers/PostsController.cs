using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MongoBlog.Web.Domain.Entities;
using MongoBlog.Web.Domain.Services;
using MongoBlog.Web.Presentation.ViewModels;
using Norm;

namespace MongoBlog.Web.Presentation.Controllers {
    public class PostsController : ApplicationController {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository) {
            _postRepository = postRepository;
        }

        public ActionResult Index() {
            IEnumerable<Post> posts = _postRepository.GetAll(SelectSpec.Default);
            return View(posts);
        }


        public ActionResult Create() {
            return View(new PostForm());
        }

        [HttpPost]
        public ActionResult Create(PostForm postForm) {
            var post = new Post
                           {
                               Title = postForm.Title,
                               Body = postForm.Body,
                               Author = "Khaja Minhajuddin",
                               CreatedOn = DateTime.Now
                           };
            _postRepository.Create(post);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id) {
            var post = _postRepository.Get<Post>(new ObjectId(id));
            return View(post);
        }
    }
}