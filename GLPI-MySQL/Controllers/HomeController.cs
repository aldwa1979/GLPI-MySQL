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
            var model =_computerRepository.GetAllComputers();

            //var model = _computerRepository.GetComputer();// .Computers.OrderBy(p => p.Id).Where(s => s.Realname == "Kielban").ToList();
            return View(model);
        }
    }
}