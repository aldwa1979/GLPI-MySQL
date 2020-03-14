using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class Cenniki
    {
        public long ID { get; set; }
        [Required]
        [Display(Name = "Kod hotelu")]
        public string Hotel { get; set; }
        [Display(Name = "Osoba")]
        public string RolaOsoby { get; set; }
        [Display(Name = "Kod pokoju")]
        public string KodPokoju { get; set; }
        [Display(Name = "Długość pobytu")]
        public string Okres { get; set; }
        [Required(ErrorMessage = "Proszę wpisać kod hotelu")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Data cennika")]
        public DateTime DataRezerwacji { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Data rozpoczęcia pobytu")]
        public DateTime? DataWylotu { get; set; }
        public string Lotnisko { get; set; }
        [Display(Name = "Wyżywienie")]
        public string Wyzywienie { get; set; }
        [Display(Name = "Cena")]
        public int? Cena { get; set; }
        [Display(Name = "Cennik")]
        public string Kategoria { get; set; }
    }
}
