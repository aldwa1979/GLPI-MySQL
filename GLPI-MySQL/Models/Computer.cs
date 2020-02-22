using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Firstname { get; set; }
        public string Realname { get; set; }
        public string Serial { get; set; }
        public string Code { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string SystemOp { get; set; }
        public string ContactNumber { get; set; }
    }
}
