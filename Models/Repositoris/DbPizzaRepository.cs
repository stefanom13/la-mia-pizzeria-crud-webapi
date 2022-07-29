using la_mia_pizzeria_mvc_refactoring.Database;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_mvc_refactoring.Models.Repositoris
{
    public class DbPizzaRepository
    {
        public void Create(Pizza post, List<string> selectedTags)
        {
            using (PizzaContext context = new PizzaContext())
            {
                post.Ingredienti = new List<Ingredienti>();
                if (selectedTags != null)
                {
                    foreach (string selectedTagId in selectedTags)
                    {
                        int selectedIntTagId = int.Parse(selectedTagId);
                        Ingredienti ingredienti = context.Ingrediente.Where(m => m.Id == selectedIntTagId).FirstOrDefault();
                        post.Ingredienti.Add(ingredienti);
                    }
                }
                context.Pizze.Add(post);
                context.SaveChanges();
            }
        }
        public void Delete(Pizza post)
        {
            using (PizzaContext context = new PizzaContext())
            {
                context.Pizze.Remove(post);
                context.SaveChanges();
            }
        }
        public Pizza GetById(int id)
        {
            using (PizzaContext context = new PizzaContext())
            {
                Pizza postFound = context.Pizze.Where(post => post.Id == id).Include(post =>
                post.Categorie).Include(m => m.Ingredienti).FirstOrDefault();
                return postFound;
            }
        }
        public List<Pizza> GetList()
        {
            using (PizzaContext context = new PizzaContext())
            {
                IQueryable<Pizza> posts = context.Pizze;
                return posts.ToList();
            }
        }


    }

}