using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

public class PizzaCategorie
    {

   
        public Pizza Pizza { set; get; }
        public List<Categoria>? Categorie { get; set; }
        
    
        public List<SelectListItem>? ListaIngredienti { get; set; }
        public List<string>? SelezionaIngrediente { get; set; }



    public PizzaCategorie()
        {


        }
    }

