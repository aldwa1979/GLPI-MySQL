using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class ComputerRepository : IComputerRepository
    {
        //private readonly List<Computer> _computersList;

        public IEnumerable<Computer> GetAllComputers()
        {
            throw new NotImplementedException();
        }

        public Computer GetComputer(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Computer> Names()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Computer> IComputerRepository.GetComputer(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IComputerRepository.Names()
        {
            throw new NotImplementedException();
        }
    }
}
