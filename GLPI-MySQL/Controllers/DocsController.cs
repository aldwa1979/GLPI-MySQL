using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GLPI_MySQL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GLPI_MySQL.Controllers
{
    [Authorize]
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

            using (MemoryStream stream = new MemoryStream())
            {
                var document = new PDF_Docs().PdfDocsSchemaHandover(docsOut);
                document.Save(stream, false);
                return File(stream.ToArray(), "application/pdf");
            }
        }

        //Return Report
        public IActionResult ReturnIndex(int id)
        {
            PDF_Docs pdf = new PDF_Docs();
            var docsOut = _computerRepository.GetComputer(id);

            using (MemoryStream stream = new MemoryStream())
            {
                var document = new PDF_Docs().PdfDocsSchemaReturn(docsOut);
                document.Save(stream, false);
                return File(stream.ToArray(), "application/pdf");
            }
        }

        public IActionResult Details (int id)
        {
            return View(_computerRepository.GetComputer(id));
        }

        //Handover Report
        public IActionResult HandoverDetails(int id)
        {
            PDF_Docs pdf = new PDF_Docs();
            var docsOut = _computerRepository.GetComputer(id);

            using (MemoryStream stream = new MemoryStream())
            {
                var document = new PDF_Docs().PdfDocsSchemaHandover(docsOut);
                document.Save(stream, false);
                return File(stream.ToArray(), "application/pdf");
            }
        }

        //Return Report
        public IActionResult ReturnDetails(int id)
        {
            PDF_Docs pdf = new PDF_Docs();
            var docsOut = _computerRepository.GetComputer(id);

            using (MemoryStream stream = new MemoryStream())
            {
                var document = new PDF_Docs().PdfDocsSchemaReturn(docsOut);
                document.Save(stream, false);
                return File(stream.ToArray(), "application/pdf");
            }
        }

        public IActionResult EquipmentReport()
        {
            IQueryable<Computer> equipmentQuery = _computerRepository.GetAllComputersQuery();

            var report = new Excel_Docs().GetEquipmentReport(equipmentQuery);

            return File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ListaSprzetu.xlsx");
        }

    }
}