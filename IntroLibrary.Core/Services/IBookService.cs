using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IntroLibrary.Core.DTOs;
using IntroLibrary.Core.Models;
using IntroLibrary.Core.Repositories;

namespace IntroLibrary.Core.Services
{
    public interface IBookService
    {
        
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private Mapper _mapper;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDto>());
            _mapper = new Mapper(configuration);
        }

        IEnumerable<BookDto> GetAllBooks()
        {
            return _mapper.Map<IEnumerable<BookDto>>(_bookRepository.GetBooks());
        }

        BookDto GetBook(int id)
        {
            return _mapper.Map<BookDto>(_bookRepository.GetBook(id));
        }

        BookDto GetBook(string search)
        {
            var author = _bookRepository.GetBookByAuthor(search);
            var title = _bookRepository.GetBookByTitle(search);
            return _mapper.Map<BookDto>(author ?? title);
        }
    }
}