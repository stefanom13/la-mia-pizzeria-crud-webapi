using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string TestoMessaggio { get; set; }
        

        public Message()
        {

        }

     
    }

