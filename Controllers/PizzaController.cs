using la_mia_pizzeria_mvc_refactoring.Database;

using la_mia_pizzeria_mvc_refactoring.Models.Repositoris;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_mvc_refactoring.Controllers
{
    public class PizzaController : Controller
    {
        private DbPizzaRepository pizzaRepository;

        public PizzaController()
        {
            this.pizzaRepository = new DbPizzaRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> posts = pizzaRepository.GetList();
            return View("Index", posts);
        }


        //GET: PizzaController/Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            // aggiungiamo l'include di Tags
            Pizza postFound = pizzaRepository.GetById(id);
            if (postFound == null)
            {
                return NotFound($"Il post con id {id} non è stato trovato");
            }
            else
            {
                return View("Details", postFound);
            }
        }

        //GET: PizzaController/Create
        [HttpGet]
        public IActionResult Create()
        {
            using (PizzaContext context = new PizzaContext())
            {
                List<Categoria> categories = context.Categorie.ToList();
                List<Ingredienti> tags = context.Ingrediente.ToList();
                PizzaCategorie model = new PizzaCategorie();
                model.Pizza = new Pizza();
                model.Categorie = categories;
                List<SelectListItem> listTags = new List<SelectListItem>();
                foreach (Ingredienti tag in tags)
                {
                    listTags.Add(new SelectListItem() { Text = tag.NomeIngrediente, Value = tag.Id.ToString() });
                }
                model.ListaIngredienti = listTags;
                return View("Create", model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaCategorie data)
        {
            if (!ModelState.IsValid)
            {
                using (PizzaContext context = new PizzaContext())
                {
                    // In caso di errore di validazione dobbiamo restituire ogni volta il model
                    // popolato con la lista delle categorie, perchè questi dati non vengono
                    // passati dal post e restituendolo direttamente la property Categories
                    // sarebbe null e la pagina darebbe errore
                    List<Categoria> categories = context.Categorie.ToList();
                    List<Ingredienti> tags = context.Ingrediente.ToList();
                    data.Categorie = categories;
                    List<SelectListItem> listTags = new List<SelectListItem>();
                    foreach (Ingredienti tag in tags)
                    {
                        listTags.Add(new SelectListItem() { Text = tag.NomeIngrediente, Value = tag.Id.ToString() });
                    }
                    data.ListaIngredienti = listTags;
                    return View("Create", data);
                }
            }
            Pizza postToCreate = new Pizza();
            postToCreate.NomePizza = data.Pizza.NomePizza;
            postToCreate.Descrizione = data.Pizza.Descrizione;
            postToCreate.PathImage = data.Pizza.PathImage;
            postToCreate.Prezzo = data.Pizza.Prezzo;
            postToCreate.CategoriaId = data.Pizza.CategoriaId;
            pizzaRepository.Create(postToCreate, data.SelezionaIngrediente);
            return RedirectToAction("Index");
        }



        // GET: HomeController1
        //public ActionResult Index()
        //{
        // using (PizzaContext db = new PizzaContext())
        // {
        //   IQueryable<Pizza> listPizza = db.Pizze.Include(piz => piz.Categorie);
        // // List<Pizza> listPizza = db.Pizzas.OrderBy(pizza => pizza.Id).ToList<Pizza>();
        // if (listPizza == null)
        // {
        ///  return NotFound("Pizze non presenti");
        // }
        //return View("Index", listPizza.ToList());
        //}
        //}

        // GET: HomeController1/Details/5
        //public ActionResult Details(int id)
        //{
        //    using (PizzaContext db = new PizzaContext())
        //    {
        //        //Pizza pizza = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();
        //        Pizza pizza = db.Pizze.Where(pizza => pizza.Id == id).Include(cat => cat.Categorie).FirstOrDefault();

        //        if (pizza == null)
        //        {
        //            return NotFound("Pizza non trovata");
        //        }
        //        else
        //        {
        //            db.Entry(pizza).Collection("Ingredienti").Load();
        //            return View("Details", pizza);
        //        }
        //    }
        //}

        //// GET: HomeController1/Create
        //public ActionResult Create()
        //{
        //    using (PizzaContext db = new PizzaContext())
        //    {
        //        List<Categoria> categoria = db.Categorie.ToList();
        //       // List<Ingredienti> ListaIngredieni = db.Ingrediente.ToList();
        //        PizzaCategorie model = new PizzaCategorie();

        //        model.Pizza = new Pizza();
        //        model.Categorie = categoria;
        //        model.ListaIngredienti = NuovoMetodo();


        //        return View(model);
        //    }
        //}



        //// POST: HomeController1/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(PizzaCategorie p)
        //{
        //    using (PizzaContext db = new PizzaContext())
        //    {


        //        if (!ModelState.IsValid)
        //        {
        //            List<Categoria> categoria = db.Categorie.ToList();
        //            // List<Ingredienti> ListaIngredieni = db.Ingrediente.ToList();


        //            p.Pizza = new Pizza();
        //            p.Categorie = categoria;
        //            p.ListaIngredienti = NuovoMetodo();


        //            return View("Create", p);
        //            /// p.Categorie = db.Categorie.ToList();
        //            // return View("Create", p);
        //        }
        //    }
        //        using (PizzaContext db = new PizzaContext())
        //        {
        //            Pizza newPizza = new Pizza();
        //            newPizza.NomePizza = p.Pizza.NomePizza;
        //            newPizza.Descrizione = p.Pizza.Descrizione;
        //            newPizza.Prezzo = p.Pizza.Prezzo;
        //            newPizza.PathImage = p.Pizza.PathImage;
        //            newPizza.CategoriaId = p.Pizza.CategoriaId;
        //            newPizza.Ingredienti = new List<Ingredienti>();

        //            if (p.SelezionaIngrediente != null)
        //            {
        //                foreach (string ingredient in p.SelezionaIngrediente)
        //                {
        //                    int selectedIntTagId = Int32.Parse(ingredient);

        //                    Ingredienti ingrediente = db.Ingrediente.Where(p => p.Id == selectedIntTagId).FirstOrDefault();

        //                    newPizza.Ingredienti.Add(ingrediente);
        //                }
        //            }
        //            db.Pizze.Add(newPizza);

        //            db.SaveChanges();

        //        }
        //    return RedirectToAction("Index");

        //}
        //static List<SelectListItem>? NuovoMetodo()
        //{
        //    using (PizzaContext db = new PizzaContext())
        //    {
        //        List<SelectListItem> ingredientiLista = new List<SelectListItem>();
        //        List<Ingredienti> ingredients = db.Ingrediente.ToList();

        //        foreach (Ingredienti ingrediente in ingredients)
        //        {
        //            ingredientiLista.Add(new SelectListItem() { Text = ingrediente.NomeIngrediente, Value = ingrediente.Id.ToString() });
        //        }

        //        return ingredientiLista;
        //    }
        //}

        //// GET: HomeController1/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    using (PizzaContext db = new PizzaContext())
        //    {
        //        Pizza pizzaEdit = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
        //        if (pizzaEdit == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            PizzaCategorie model = new PizzaCategorie();

        //            model.Pizza = pizzaEdit;
        //            model.Categorie = db.Categorie.ToList();

        //            return View(model);
        //        }
        //    }
        //}

        //// POST: HomeController1/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, PizzaCategorie p)
        //{
        //    using (PizzaContext db = new PizzaContext())
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            p.Categorie = db.Categorie.ToList();
        //            return View("Edit", p);
        //        }

        //        Pizza pizzaEdit = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();


        //        if (pizzaEdit != null)
        //        {
        //            pizzaEdit.NomePizza = p.Pizza.NomePizza;
        //            pizzaEdit.Descrizione = p.Pizza.Descrizione;
        //            pizzaEdit.PathImage = p.Pizza.PathImage;
        //            pizzaEdit.Prezzo = p.Pizza.Prezzo;
        //            pizzaEdit.CategoriaId = p.Pizza.CategoriaId;

        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            return NotFound(View("Error"));
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}

        //// GET: HomeController1/Delete/5

        //// POST: HomeController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    using (PizzaContext db = new PizzaContext())
        //    {
        //        Pizza pizzaDelete = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

        //        if (pizzaDelete == null)
        //        {

        //            return NotFound();
        //        }
        //        else
        //        {
        //            db.Pizze.Remove(pizzaDelete);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //}
    }
}
