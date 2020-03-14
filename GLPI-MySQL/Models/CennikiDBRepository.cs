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
            string dateOfBC = $"\'{date.ToString("yyyy-MM-dd")}\'";
            string hotel = $"\'ATHGALI\'";

            object[] param =
            {
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year),
                new SqlParameter("@DateOfBC", dateOfBC),
                new SqlParameter("@Hotel", hotel)
            };

            return context.Cenniki.FromSql("Cenniki @Year, @Month, @Hotel, @DateOfBC", param).Take(0).ToList();
        }

        public IEnumerable<Cenniki> GetCenniki(Cenniki cenniki)
        {
            int year = cenniki.DataRezerwacji.Year;
            string month = cenniki.DataRezerwacji.Month.ToString("d2");
            string dateOfBC = $"\'{cenniki.DataRezerwacji.ToString("yyyy-MM-dd")}\'";
            string hotel = $"\'{cenniki.Hotel}\'";

            object[] param =
            {
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year),
                new SqlParameter("@Hotel", hotel),
                new SqlParameter("@DateOfBC", dateOfBC)

            };

            return context.Cenniki.FromSql("Cenniki @Year, @Month, @Hotel, @DateOfBC", param).ToList();
        }
    }
}
