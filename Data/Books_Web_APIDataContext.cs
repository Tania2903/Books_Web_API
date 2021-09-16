using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Books_Web_API.BusinessLayer;

namespace Books_Web_API.Models
{
    //Connects the business layer to the underlying databse tables.
    public class Books_Web_APIDataContext : DbContext
    {
        public Books_Web_APIDataContext (DbContextOptions<Books_Web_APIDataContext> options)
            : base(options)
        {
        }

        public DbSet<Books_Web_API.BusinessLayer.Book> Book { get; set; }
    }
}
