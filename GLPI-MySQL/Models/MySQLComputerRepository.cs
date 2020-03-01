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

        public IEnumerable<User> Names()
        {
            return context.Users.ToList();
        }

        public IEnumerable<PhoneNumber> GrecosPhoneNumbers()
        {
            return context.PhoneNumbers.ToList();
        }

        public IEnumerable<Computer> GetAllComputers()
        {
            return context.Computers.ToList();
        }

        public IEnumerable<Computer> GetComputer(int Id)
        {
            return context.Computers.Where(p => p.Id_User == Id).ToList();
         }

        public IQueryable<Computer> GetAllComputersQuery()
        {
            return context.Computers;
        }

        public IQueryable<PhoneNumber> GetAllPhonesQuery()
        {
            return context.PhoneNumbers.OrderBy(p=>p.Realname);
        }
    }
}
