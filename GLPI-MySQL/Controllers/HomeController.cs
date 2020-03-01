using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLPI_MySQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GLPI_MySQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComputerRepository _computerRepository;

        public HomeController(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}