﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVC_Voorbeeld3.CustomValidation;

namespace MVC_Voorbeeld3.Models
{
    public class Persoon
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Gelieve een voornaam op te geven")]
        public string Voornaam { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Gelieve een familienaam op te geven")]
        public string Familienaam { get; set; }


        public int Score { get; set; }

        [Range(1, 5000, ErrorMessage = "De wedde moet tussen 1 en 5000 liggen")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal Wedde { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Gelieve een wachtwoord in te geven")]
        [StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessage = "Je {0} moet minstens {2} en hoogstens {1} tekens bevatten")]
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]
        public string Paswoord { get; set; }

        [Compare("Paswoord", ErrorMessage = "Beide passwoorden moeten hetzelfde zijn")]
        [Display(Name = "Herhaal Wachtwoord")]
        [DataType(DataType.Password)]
        public string HerhaalPaswoord { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Gelieve een geboortedatum op te geven")]
        //[MinAgeAttribute(ErrorMessage = "De minimum leeftijd bedraagt 18 jaar")]
        //[System.Web.Mvc.Remote("ValidateDOB", "Persoon")]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Geboren { get; set; }

        public bool Gehuwd { get; set; }

        [DataType(DataType.MultilineText)]
        public string Opmerkingen { get; set; }

        public Geslacht Geslacht { get; set; }
    }
}