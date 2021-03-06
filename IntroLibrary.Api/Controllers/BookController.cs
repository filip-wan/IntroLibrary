﻿using System;
using System.Linq;
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
            var result = _service.GetBook(search);
            return result == null ? (IActionResult)NotFound() : Ok(_service.GetBook(search));
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

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result =_service.UpdateBook(id, book);
            return result == null ? (IActionResult)BadRequest() : Ok(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _service.DeleteBook(id);
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }
    }
}
