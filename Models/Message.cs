using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

//[Table"Message"] ;
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string TestoMessaggio { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }
        

        public Message()
        {

        }

     
    }

