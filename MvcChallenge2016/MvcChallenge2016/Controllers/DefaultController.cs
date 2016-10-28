using MvcChallenge2016.Models;
using MvcChallenge2016.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcChallenge2016.Controllers
{
    public class DefaultController : Controller
    {
        LibraryEntities dbContext = new LibraryEntities();
        // GET: Default
        public ActionResult Index(bool Layout = true)
        {
            BookListModel model = new BookListModel();
            model.Initialize(dbContext);

            if (Layout)
            {
                return View("BookList", model);
            }
            else
            {
                return PartialView("Index", model);
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid? BookID)
        {
            BookEditModel model = new BookEditModel();
            Book b = dbContext.Books.FirstOrDefault(x => x.BookID == BookID);
            model.Load(b);
            return PartialView("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(BookEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Book b = dbContext.Books.FirstOrDefault(x => x.BookID == model.BookID);
            model.Set(b);

            //There is some magic that goes on here.
            //How does it know what needs to be saved if I'm not telling it anywhere in the code?
            dbContext.SaveChanges();
            return RedirectToAction("Index", new { Layout = false });
        }


        [HttpGet]
        public ActionResult Add()
        {
            BookModel model = new BookModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(BookModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Book b = new Book();
            model.Set(b);

            dbContext.Books.Add(b);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Guid bookID)
        {
            Book b = dbContext.Books.FirstOrDefault(x => x.BookID == bookID);
            dbContext.Books.Remove(b);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}