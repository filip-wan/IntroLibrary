using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using IntroLibrary.Core.DTOs;
using IntroLibrary.Core.Models;
using IntroLibrary.Core.Repositories;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace IntroLibrary.Core.Services
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks();
        BookDto GetBook(int id);
        IEnumerable<BookDto> GetBook(string search);
        BookDto AddBook(BookDto bookDto);
        BookDto UpdateBook(int id, BookDto bookDto);
        BookDto DeleteBook(int id);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;

            _mapper = mapper;
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            return _mapper.Map<IEnumerable<BookDto>>(_bookRepository.GetBooks());
        }

        public BookDto GetBook(int id)
        {
            return _mapper.Map<BookDto>(_bookRepository.GetBook(id));
        }

        public IEnumerable<BookDto> GetBook(string search)
        {
            var result = new HashSet<Book>();
            result.UnionWith( _bookRepository.GetBookByAuthor(search));
            result.UnionWith(_bookRepository.GetBookByTitle(search));
            return result.Count > 0 ? _mapper.Map<IEnumerable<BookDto>>(result) : null;
        }

        public BookDto AddBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            if (!Validator.TryValidateObject(book, new ValidationContext(book), new List<ValidationResult>(), true))
                return null;

            book = _bookRepository.AddBook(book);
            return _mapper.Map<BookDto>(book);

        }

        public BookDto UpdateBook(int id, BookDto bookDto)
        {
            var book = _bookRepository.GetBook(id);
            if (book == null) return null;

            var updatedBook = _mapper.Map<Book>(bookDto);
            updatedBook.ID = id;

            updatedBook = _bookRepository.UpdateBook(updatedBook);

            return updatedBook == null ? null : _mapper.Map<BookDto>(updatedBook);
        }

        public BookDto DeleteBook(int id)
        {
            var book = _bookRepository.DeleteBook(id);
            return book == null ? null : _mapper.Map<BookDto>(book);
        }
    }
}