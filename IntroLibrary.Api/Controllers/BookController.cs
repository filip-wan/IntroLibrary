using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroLibrary.Core.Repositories;
using IntroLibrary.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IntroLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;

        public BookController(BookService service)
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
        public IActionResult Post()
        {
            throw new NotImplementedException();
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
