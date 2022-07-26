

using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_mvc_refactoring.Database
{

    public class PizzaContext : DbContext
    {
        

        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Ingredienti> Ingrediente { get; set; }

         public DbSet<Categoria> Categorie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizzeriaExperis;Integrated Security=True");
        }


    }


}

