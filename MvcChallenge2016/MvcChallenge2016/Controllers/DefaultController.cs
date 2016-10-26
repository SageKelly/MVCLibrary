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
        // GET: Default
        public ActionResult Index()
        {
            using (LibraryEntities dbContext = new LibraryEntities())
            {
                BookListModel model = new BookListModel();
                model.Initialize(dbContext);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid? BookID)
        {
            using (LibraryEntities dbContext = new LibraryEntities())
            {
                BookEditModel model = new BookEditModel();
                model.Initialize(dbContext, BookID);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(BookEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (LibraryEntities dbContext = new LibraryEntities())
            {
                Book b = new Book();
                b.BookID = (Guid)model.BookID;
                b.Title = model.Title;
                b.AuthorName = model.Author;

                dbContext.Books.Add(b);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
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
            using (LibraryEntities dbContext = new LibraryEntities())
            {
                Book b = new Book();
                b.BookID = (Guid)model.BookID;
                b.Title = model.BookTitle;
                b.AuthorName = model.AuthorName;

                dbContext.Books.Add(b);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}