using System;
using IntroLibrary.Core.DTOs;
using IntroLibrary.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntroLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllBooks());
        }

        [HttpGet("{search}")]
        public IActionResult GetByString([FromRoute] string search)
        {
            return Ok(_service.GetBook(search));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.AddBook(book);
            return result == null ? (IActionResult) BadRequest() : Ok(result);
        }

        [HttpPut]
        public IActionResult Put()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
