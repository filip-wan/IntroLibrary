using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IntroLibrary.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Post()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IEnumerable<WeatherForecast> Put()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IEnumerable<WeatherForecast> Delete()
        {
            throw new NotImplementedException();
        }
    }
}
