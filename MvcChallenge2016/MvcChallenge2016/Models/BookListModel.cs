using MvcChallenge2016.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcChallenge2016.Models
{
    public class BookListModel
    {
        public List<Book> Books { get; set; }

        public void Initialize(LibraryEntities dbContext)
        {
            Books = new List<Book>();
            Books = dbContext.Books.ToList();
        }
    }
}