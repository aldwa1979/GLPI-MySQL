using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class Cenniki
    {
        public long ID { get; set; }
        public string Hotel { get; set; }
        public string RolaOsoby { get; set; }
        public string KodPokoju { get; set; }
        public string Okres { get; set; }
        public DateTime DataRezerwacji { get; set; }
        public DateTime DataWylotu { get; set; }
        public string Lotnisko { get; set; }
        public string Wyzywienie { get; set; }
        public int Cena { get; set; }
        public string Kategoria { get; set; }
    }
}
