using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public interface IComputerRepository
    {
        Computer GetComputer(int Id);
        IEnumerable<Computer> GetAllComputers();
        IEnumerable<User> Names();
    }
}
