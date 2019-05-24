using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net.Core.Mongo.PoC.Interfaces;
using Net.Core.Mongo.PoC.Models;

namespace Net.Core.Mongo.PoC.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookRepository.GetAllBooks();
        }
    }
}