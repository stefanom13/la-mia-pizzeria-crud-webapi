using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Pizze")]
[Index(nameof(NomePizza), IsUnique = true)]
public class Pizza
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NomePizza { get; set; }
    public string Descrizione { get; set; }
    public string PathImage { get; set; }
    public float Prezzo { get; set; }
    public int? CategoriaId { get; set; }
    public Categoria? Categorie { get; set; }

    public List<Ingredienti>? Ingredienti { get; set; }
    public Pizza(string nomePizza, string descrizione, string pathImage, float prezzo)
    {

        NomePizza = nomePizza;
        Descrizione = descrizione;
        PathImage = pathImage;
        Prezzo = prezzo;
    }
    public Pizza()
    {
    }


}



