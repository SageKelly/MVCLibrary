using MvcChallenge2016.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcChallenge2016.Models
{
    public class BookEditModel
    {
        public Guid? BookID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This is required")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This is required")]
        public string Author { get; set; }


        public void Load(Book model)
        {
            BookID = model.BookID;
            Title = model.Title;
            Author = model.AuthorName;
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
            model.BookID = (Guid)this.BookID;
            model.AuthorName = this.Author;
            model.Title = this.Title;
        }
    }
}