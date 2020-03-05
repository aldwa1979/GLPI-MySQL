using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class CennikDBContext : DbContext
    {
        public CennikDBContext(DbContextOptions<CennikDBContext> option) : base (option)
        {

        }

        public DbSet<Cenniki> Cenniki { get; set; }
  
    }
}
