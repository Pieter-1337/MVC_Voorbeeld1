using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Voorbeeld3.Models
{
    public class Filiaal
    {

        public int ID { get; set; }
        public string Naam { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy}")]
        [UIHint("sterretjes")]
        public DateTime Gebouwd { get; set; }

        
        public decimal Waarde { get; set; }

        public Eigenaar Eigenaar { get; set; }


    }
}