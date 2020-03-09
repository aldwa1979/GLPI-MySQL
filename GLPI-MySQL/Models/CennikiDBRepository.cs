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

        public IEnumerable<Cenniki> GetCenniki(DateTime date)
        {
            
            int year = date.Year;
            string month = date.Month.ToString("d2");

            object[] param =
            {
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year)
            };

            return context.Cenniki.FromSql("Cenniki @Year, @Month", param).ToList();
        }
    }
}
