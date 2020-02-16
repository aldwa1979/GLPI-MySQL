using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class MySQLComputerRepository : IComputerRepository
    {
        private readonly MySQLContext context;

        public MySQLComputerRepository(MySQLContext context)
        {
            this.context = context;
        }

        public IEnumerable<Computer> GetAllComputers()
        {
            return context.Computers.OrderBy(p => p.Id).Where(s => s.Realname == "Kielban").ToList();
        }

        public Computer GetComputer(int Id)
        {
            var comp = context.Computers.Where(p => p.Id == Id);
            return comp.FirstOrDefault();
        }
    }
}
