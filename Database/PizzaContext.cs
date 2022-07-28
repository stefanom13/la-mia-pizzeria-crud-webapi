
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_mvc_refactoring.Database
{

    public class PizzaContext : IdentityDbContext<IdentityUser>
    {
        public PizzaContext()
        {
        }
        public PizzaContext(DbContextOptions<PizzaContext> options)
        : base(options)
        {
        }

        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Ingredienti> Ingrediente { get; set; }
        public DbSet<Message> Messaggi { get; set; }

         public DbSet<Categoria> Categorie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizzeriaExperis;Integrated Security=True");
        }


    }


}

