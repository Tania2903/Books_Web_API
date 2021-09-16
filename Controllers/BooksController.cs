using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Books_Web_API.BusinessLayer;
using Books_Web_API.Models;

namespace Books_Web_API.Controllers
{
    //Books API controller 
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Books_Web_APIDataContext _context;

        public BooksController(Books_Web_APIDataContext context)
        {
            _context = context;
        }

        // GET: api/Books
        //Gets all books using a linq query.
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBook()
        {
            return (from books in _context.Book select books).ToList();
        }

        // GET: api/Books/5
        //Gets a book using a linq query.
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = (from books in _context.Book
                        where books.Id == id
                        select books).FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates a book.
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds  a book to the database.
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        //Removes  a boook uses a linq query to select the book
        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBook(int id)
        {
            var book = (from books in _context.Book
                        where books.Id == id
                        select books).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
             _context.SaveChanges();

            return book;
        }

        //Checks the book for existance using a lamda query.
        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
