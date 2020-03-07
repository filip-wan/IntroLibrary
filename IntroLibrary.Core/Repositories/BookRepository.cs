using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IntroLibrary.Core.Models;
using Microsoft.Extensions.Options;

namespace IntroLibrary.Core.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        IEnumerable<Book> GetBookByTitle(string title);
        IEnumerable<Book> GetBookByAuthor(string author);
    }

    public class BookRepository : IBookRepository
    {
        private readonly dbContext _context;

        public BookRepository(dbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>(_context.Books);
        }

        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(b => b.ID == id);
        }

        public IEnumerable<Book> GetBookByTitle(string title)
        {
            return _context.Books.FindAll(b => b.Title == title);
        }

        public IEnumerable<Book> GetBookByAuthor(string author)
        {
            return _context.Books.FindAll(b => b.Author == author);
        }
    }
}