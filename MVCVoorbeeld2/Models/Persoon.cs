using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCVoorbeeld2.Models
{
    public class Persoon
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string Voornaam { get; set; }
        [DisplayFormat(DataFormatString = "{0:#, ##0.00}")]
        public string Familienaam { get; set; }

    }
}