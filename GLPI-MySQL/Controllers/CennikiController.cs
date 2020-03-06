using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GLPI_MySQL.Models;

namespace GLPI_MySQL.Controllers
{
    public class CennikiController : Controller
    {
        private readonly ICennikiRepository _cennikiRepository;

        public CennikiController(ICennikiRepository cennikiRepository)
        {
            _cennikiRepository = cennikiRepository;
        }

        public IActionResult Index()
        {
            DateTime dataRezerwacji = DateTime.Parse("09.03.2020 00:00:00");

            var model = _cennikiRepository.GetCenniki(dataRezerwacji);
            return View(model);
        }
    }
}