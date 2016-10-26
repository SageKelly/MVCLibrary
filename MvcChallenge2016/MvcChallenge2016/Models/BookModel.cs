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

    }
}