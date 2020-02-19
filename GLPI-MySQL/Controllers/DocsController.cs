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

        public IActionResult Index(string searchBy, string search)
        {
            if (search != null)
            {
                if (searchBy == "Realname")
                    return View(_computerRepository.Names().Where(p => p.Realname.Contains(search)).ToList());
                else
                    return View(_computerRepository.Names().Where(p => p.Firstname.Contains(search)).ToList());
            }
            else
                return View(_computerRepository.Names().ToList());
        }

        //public IActionResult Index(string search)
        //{
        //    if (search != null)
        //        return View(_computerRepository.Names().Where(p => p.Realname.Contains(search)).ToList());
        //    else
        //        return View(_computerRepository.Names().ToList());
        //}

        public IActionResult Details (int id)
        {
            return View(_computerRepository.GetComputer(id));
        }
    }
}