using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        [Display(Name = "Imie")]
        public string Firstname { get; set; }
        [Display(Name = "Nazwisko")]
        public string Realname { get; set; }
        [Display(Name = "Stanowisko")]
        public string Position { get; set; }
        [Display(Name = "Dział")]
        public string Department { get; set; }
        [Display(Name = "Zespół")]
        public string Team { get; set; }
        [Display(Name = "Numer telefonu")]
        public string ContactNumber { get; set; }
    }
}
