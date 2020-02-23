﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Imie")]
        public string Firstname { get; set; }
        [Display(Name = "Nazwisko")]
        public string Realname { get; set; }
    }
}
