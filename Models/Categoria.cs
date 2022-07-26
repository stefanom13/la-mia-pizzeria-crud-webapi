using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string NomeCategoria { get; set; }

        [JsonIgnore]
        public List<Pizza> Pizze { get; set; }
        public Categoria()
        {


        }
    }

