﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public interface IComputerRepository
    {
        IEnumerable<Computer> GetComputer(int Id);
        IEnumerable<Computer> GetAllComputers();
        IEnumerable<User> Names();
        IEnumerable<PhoneNumber> GrecosPhoneNumbers();
        IQueryable<Computer> GetAllComputersQuery();
        IQueryable<PhoneNumber> GetAllPhonesQuery();
    }
}
