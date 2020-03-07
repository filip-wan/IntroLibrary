using System;
using System.Collections.Generic;
using System.Linq;
using IntroLibrary.Core.Models;

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
        private readonly List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            _books.Add(
                new Book
                {
                    ID = 1,
                    Author = "Jules Verne",
                    Title = "Twenty Thousand Leagues Under the Sea",
                    ReleaseDate = new DateTime(1992, 04, 15)
                });
            _books.Add(
                new Book
                {
                    ID = 2,
                    Author = "Jules Verne",
                    Title = "Journey to the Center of the Earth",
                    ReleaseDate = new DateTime(1993, 11, 01)
                }
            );
            
        }

        public IEnumerable<Book> GetBooks()
        {
            var books = _books;
            return new List<Book>(books);
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(b => b.ID == id);
        }

        public IEnumerable<Book> GetBookByTitle(string title)
        {
            return _books.FindAll(b => b.Title.Contains(title));
        }

        public IEnumerable<Book> GetBookByAuthor(string author)
        {
            return _books.FindAll(b => b.Author.Contains(author));
        }
    }
}