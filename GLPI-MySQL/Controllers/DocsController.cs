using System;
using System.Collections.Generic;
using System.IO;
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
                    return View(_computerRepository.Names().Where(p => p.Realname.Contains((search), StringComparison.CurrentCultureIgnoreCase)).ToList());
                else
                    return View(_computerRepository.Names().Where(p => p.Firstname.Contains((search), StringComparison.CurrentCultureIgnoreCase)).ToList());
            }
            else
                return View(_computerRepository.Names().ToList());
        }

        //Handover Report
        public IActionResult HandoverIndex(int id)
        {
            PDF_Docs pdf = new PDF_Docs();

            var docsOut = _computerRepository.GetComputer(id);
            pdf.PdfDocsSchemaHandover(docsOut);

            return RedirectToAction("Index", "Docs");
        }

        //Return Report
        public IActionResult ReturnIndex(int id)
        {
            PDF_Docs pdf = new PDF_Docs();

            var docsOut = _computerRepository.GetComputer(id);
            pdf.PdfDocsSchemaReturn(docsOut);

            return RedirectToAction("Index", "Docs");
        }

        public IActionResult Details (int id)
        {
            return View(_computerRepository.GetComputer(id));
        }

        //Handover Report
        [HttpPost]
        public IActionResult HandoverDetails(int id)
        {
            PDF_Docs pdf = new PDF_Docs();

            var docsOut = _computerRepository.GetComputer(id);
            pdf.PdfDocsSchemaHandover(docsOut);

            return RedirectToAction("Details", new { id });
        }

        //Return Report
        [HttpPost]
        public IActionResult ReturnDetails(int id)
        {
            PDF_Docs pdf = new PDF_Docs();

            var docsOut = _computerRepository.GetComputer(id);
            pdf.PdfDocsSchemaReturn(docsOut);

            return RedirectToAction("Details", new { id });
        }
    }
}