using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcChallenge2016.DataAccessLayer
{
    public class LibraryContext:DbContext
    {

        public DbSet<Book> Books { get; set; }

    }
}