﻿using la_mia_pizzeria_mvc_refactoring.Database;
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
                IQueryable<Pizza> pizza = context.Pizze.Include(pizza => pizza.Categorie).Include(pizza => pizza.Ingredienti);
                if (search != null && search != "")
                {
                    pizza = pizza.Where(p => p.NomePizza.Contains(search));
                }
                return Ok(pizza.ToList());
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (PizzaContext ctx = new PizzaContext())
            {
                Pizza pizza = ctx.Pizze.Where(p => p.Id == id).Include(p => p.Categorie).Include(p => p.Ingredienti).FirstOrDefault();

                if (pizza == null)
                {
                    return NotFound();
                }

                return Ok(pizza);
            }
        }
    }
}

