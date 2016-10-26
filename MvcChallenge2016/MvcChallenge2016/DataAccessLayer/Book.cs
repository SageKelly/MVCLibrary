using System;

namespace MvcChallenge2016.DataAccessLayer
{
    public class Book
    {
        public Guid? BookID { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }

    }
}