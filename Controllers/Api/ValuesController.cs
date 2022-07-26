using la_mia_pizzeria_mvc_refactoring.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_mvc_refactoring.Controllers.Api
{
    [Route("api/pizza")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUtenti()
        {
            using (PizzaContext context = new PizzaContext())
            {
                IQueryable<Pizza> pizze = context.Pizze.Include(pizze => pizze.Categorie);
                return Ok(pizze.ToList());
            }
        }
    }
}
