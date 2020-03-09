using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class CennikiVM
    {
        public Cenniki PriceList { get; set; }
        [Display(Name = "Wylot")]
        public string From { get; set; }
        [Display(Name = "Przylot")]
        public string To { get; set; }
    }
}
