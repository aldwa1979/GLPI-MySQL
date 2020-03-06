using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public interface ICennikiRepository
    {
        IEnumerable<Cenniki> GetCenniki(DateTime date);
        
    }
}
