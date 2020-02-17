using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        
    }
}
