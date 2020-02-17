using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GLPI_MySQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GLPI_MySQL.Controllers
{
    public class DocsController : Controller
    {
        private readonly IComputerRepository _computerRepository;

        public DocsController(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public IActionResult Index()
        {
            var test1 = new List<Object>();

            var model1 = _computerRepository.Names().OrderBy(s => s.Realname).Select(p => new { Firstname = p.Firstname.ToString(), Realname = p.Realname.ToString() }).Distinct().ToList();

  
            return View();
        }


    }
}