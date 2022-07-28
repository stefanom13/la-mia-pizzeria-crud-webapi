using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_mvc_refactoring.Database;

namespace la_mia_pizzeria_mvc_refactoring.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly PizzaContext _context;

        public MessagesController(PizzaContext context)
        {
            _context = context;
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Pizza( [FromBody] Message message)
        {

            return Ok();
        }

       
    }
}
