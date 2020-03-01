using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLPI_MySQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GLPI_MySQL.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IComputerRepository _computerRepository;

        public PhonesController(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public IActionResult Index(string searchBy, string search)
        {
            if (search != null)
            {
                if (searchBy == "Realname")
                    return View(_computerRepository.GrecosPhoneNumbers().Where(p => p.Realname.Contains((search), StringComparison.CurrentCultureIgnoreCase)).ToList());
                else
                    return View(_computerRepository.GrecosPhoneNumbers().Where(p => p.Firstname.Contains((search), StringComparison.CurrentCultureIgnoreCase)).ToList());
            }
            else
                return View(_computerRepository.GrecosPhoneNumbers().OrderBy(p=>p.Realname).ToList());
        }

        public IActionResult PhoneReport()
        {
            IQueryable<PhoneNumber> phoneQuery = _computerRepository.GetAllPhonesQuery();

            var report = new Excel_Docs().GetPhoneReport(phoneQuery);

            return File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ListaNumerow.xlsx");
        }
    }
}