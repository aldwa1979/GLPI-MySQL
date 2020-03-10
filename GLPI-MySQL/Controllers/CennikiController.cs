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

        [HttpPost]
        public IActionResult Index(string searchKodHotel, string searchRolaOsoby, DateTime searchDataCennika, DateTime? searchDataPobytu, string searchAirportPL, string searchAirportGR, string searchKodPokoju, string searchOkres, string searchWyzywienie)
        {
            DateTime dataRezerwacji = searchDataCennika;

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

            var model = _cennikiRepository
                .GetCenniki(cenniki)
                .Where(p=> 
                    p.Hotel == searchKodHotel &&
                    p.RolaOsoby == searchRolaOsoby &&
                    p.KodPokoju == searchKodPokoju &&
                    p.Okres == searchOkres &&
                    p.DataRezerwacji == searchDataCennika && 
                    p.DataWylotu == searchDataPobytu &&
                    p.Lotnisko == searchAirportPL + searchAirportGR &&
                    p.Wyzywienie == searchWyzywienie
                        );

            return View(model);
        }
    }
}