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

        public void Initialize(LibraryEntities dbContext, Guid? bookID)
        {
            Book book = dbContext.Books.FirstOrDefault(x => x.BookID == BookID);

            if (book != null)
            {
                this.BookID = bookID;
                this.Title = book.Title;
                this.Author = book.AuthorName;
            }
        }
    }
}