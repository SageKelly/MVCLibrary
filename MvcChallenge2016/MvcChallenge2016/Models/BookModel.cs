using MvcChallenge2016.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcChallenge2016.Models
{
    public class BookModel
    {
        public Guid? BookID { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }

        public void Load(Book model)
        {
            BookID = model.BookID;
            BookTitle = model.Title;
            AuthorName = model.AuthorName;
        }

        public void Initialize(LibraryEntities dbContext, Guid? bookID)
        {
            //For extra stuff, but I don't have any.
        }

        public void Set(Book model)
        {
            /*
            According to CSI, there's no need to pass the parameter by reference,
            so, at this point, I'm not sure how the information gets back now.
            */
            model.AuthorName = this.AuthorName;
            model.Title = this.BookTitle;
        }
    }
}