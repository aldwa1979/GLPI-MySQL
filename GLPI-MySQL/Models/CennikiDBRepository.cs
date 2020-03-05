using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class CennikiDBRepository : ICennikiRepository
    {
        private readonly CennikDBContext context;

        public CennikiDBRepository(CennikDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Cenniki> GetCenniki()
        {
            object[] param =
            {
                new SqlParameter("@Month", "12"),
                new SqlParameter("@Year", "2019")
            };
            
            return context.Cenniki.FromSql("cenniki @Year , @Month", param).ToList();
        }
    }
}
