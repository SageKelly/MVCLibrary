using MvcChallenge2016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcChallenge2016.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(BookEditModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Guid? book)
        {
            BookEditModel model = new BookEditModel();
            return View("Edit",model);
        }
    }
}