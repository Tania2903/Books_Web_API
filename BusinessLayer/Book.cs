using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Web_API.BusinessLayer
{

    //Book details
    public class Book
    {
        //Book id
        public int Id { get; set; }

        //Book title 
        public string Title { get; set; }

        //Author of the book
        public string Author { get; set; }

        //Published year of the book.
        public int PublishYear { get; set; }

    }
}
