using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_mvc_refactoring.Database;
using la_mia_pizzeria_mvc_refactoring.Models;

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
        public IActionResult Post( [FromBody] Message message)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                using (PizzaContext context = new PizzaContext())
                {
                    _context.Messaggi.Add(message);
                    _context.SaveChanges();

                    return Ok();
                }
               
            }
           
        }
        //[HttpGet]
        //public IActionResult Get()
       // {
            //using (PizzaContext db = new PizzaContext())
           // {
              //  IQueryable<Message> messagi = db.Messaggi;

             //   return Ok(messagi.ToList());
           // }
      //  }
    }
}
