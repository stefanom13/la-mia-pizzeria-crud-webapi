using la_mia_pizzeria_mvc_refactoring.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_mvc_refactoring.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUtenti()
        {
            using (PizzaContext context = new PizzaContext())
            {
                IQueryable<Pizza> pizze = context.Pizze;
                return Ok(pizze.ToList());
            }
        }
    }
}
