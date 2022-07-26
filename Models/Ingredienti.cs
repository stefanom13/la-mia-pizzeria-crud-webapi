using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    
    public class Ingredienti
    {
        [Key]
        public int Id { get; set; }
        public string NomeIngrediente { get; set; }
        public List<Pizza> Pizza { get; set; }

        public Ingredienti(string nomeIngrediente)
        {

            NomeIngrediente = nomeIngrediente;
        }
    }

