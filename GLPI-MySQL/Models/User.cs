using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Firstname { get; set; }
        public string Realname { get; set; }
    }
}
