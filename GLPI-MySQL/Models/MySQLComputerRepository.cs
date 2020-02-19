﻿using System;
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

        public IEnumerable<Computer> GetAllComputers()
        {
            return context.Computers.OrderBy(p => p.Id).Where(s => s.Realname == "Kielban").ToList();
        }

        public IEnumerable<Computer> GetComputer(int Id)
        {
            return context.Computers.Where(p => p.Id_User == Id).ToList();
         }
    }
}
