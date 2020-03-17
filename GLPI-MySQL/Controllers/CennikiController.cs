using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GLPI_MySQL.Models;
using Microsoft.AspNetCore.Authorization;

namespace GLPI_MySQL.Controllers
{
    [Authorize]
    public class CennikiController : Controller
    {
        private readonly ICennikiRepository _cennikiRepository;

        public CennikiController(ICennikiRepository cennikiRepository)
        {
            _cennikiRepository = cennikiRepository;
        }

        public IActionResult Index()
        {
            DateTime dataRezerwacji = DateTime.Parse("01.01.2020 00:00:00");

            var model = _cennikiRepository.GetCenniki(dataRezerwacji);
            
            return View(model);          
        }

        [HttpPost]
        public IActionResult Index(string searchKodHotel, DateTime searchDataCennika ,string searchRolaOsoby = null,  DateTime? searchDataPobytu = null, string searchAirportPL = null, string searchAirportGR = null, string searchKodPokoju = null, string searchOkres = null, string searchWyzywienie = null)
        {
            DateTime dataRezerwacji = searchDataCennika;
            string airport = null;

            if (searchAirportPL != null && searchAirportGR != null)
            {
                airport = searchAirportPL+searchAirportGR;
            }
            else
            {
                airport = null;
            }

            IEnumerable<Cenniki> model;

            Cenniki cenniki = new Cenniki()
            {
                Hotel = searchKodHotel,
                RolaOsoby = searchRolaOsoby,
                KodPokoju = searchKodPokoju,
                Okres = searchOkres,
                DataRezerwacji = searchDataCennika,
                DataWylotu = searchDataPobytu,
                Lotnisko = searchAirportPL + searchAirportGR,
                Wyzywienie = searchWyzywienie
            };

            model = _cennikiRepository
            .GetCenniki(cenniki)
            .Where(a =>
                (searchRolaOsoby != null ? a.RolaOsoby == searchRolaOsoby : true) &&
                (searchOkres != null ? a.Okres == searchOkres : true) &&
                (searchKodPokoju != null ? a.KodPokoju == searchKodPokoju : true) &&
                (searchDataPobytu != null ? a.DataWylotu == searchDataPobytu : true) &&
                (searchWyzywienie != null ? a.Wyzywienie == searchWyzywienie : true) &&
                (airport != null ? a.Lotnisko.ToLower() == airport.ToLower() : true));

            return View(model);
        }
    }
}