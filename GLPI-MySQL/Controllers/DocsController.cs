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

        //public IActionResult Index()
        //{
        //    var model = _computerRepository.Names().ToList();

        //    return View(model);
        //}


        public IActionResult Index (string searchBy, string search)
        {
            if (searchBy == "Realname")
                return View(_computerRepository.Names().Where(p => p.Realname.StartsWith(search) || search == null).ToList());
            else
                return View(_computerRepository.Names().Where(p => p.Firstname.StartsWith(search) || search == null).ToList());
        }


    }
}