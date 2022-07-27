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
        public IActionResult GetUtenti(string? search)
        {
            using (PizzaContext context = new PizzaContext())
            {
                IQueryable<Pizza> pizza = context.Pizze.Include(pizza => pizza.Categorie);
                if (search != null && search != "")
                {
                    pizza = pizza.Where(p => p.NomePizza.Contains(search));
                }
                return Ok(pizza.ToList());
            }
        }
    }
}
