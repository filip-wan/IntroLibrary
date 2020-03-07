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
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly Mapper _mapper;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            var configuration = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Book, BookDto>();
                cfg.CreateMap<BookDto, Book>();
            });
            _mapper = new Mapper(configuration);
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
    }
}