using Microsoft.AspNetCore.Mvc;
using CIS174_OlympicGames.Models;

namespace CIS174_OlympicGames.Controllers
{
    public class SportController : Controller
    {
        private static List<CountrySportModel> countries = new List<CountrySportModel>
        {
            new CountrySportModel { Country = "Austria", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/at.png" },
            new CountrySportModel { Country = "Brazil", Game = "Summer Olympics", Sport = "Road Cycling", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/br.png" },
            new CountrySportModel { Country = "Canada", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/ca.png" },
            new CountrySportModel { Country = "China", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/cn.png" },
            new CountrySportModel { Country = "Cyprus", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/cy.png" },
            new CountrySportModel { Country = "Finland", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/fi.png" },
            new CountrySportModel { Country = "France", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/fr.png" },
            new CountrySportModel { Country = "Germany", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/de.png" },
            new CountrySportModel { Country = "Great Britain", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/gb.png" },
            new CountrySportModel { Country = "Italy", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/it.png" },
            new CountrySportModel { Country = "Jamaica", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/jm.png" },
            new CountrySportModel { Country = "Japan", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/jp.png" },
            new CountrySportModel { Country = "Mexico", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/mx.png" },
            new CountrySportModel { Country = "Netherlands", Game = "Summer Olympics", Sport = "Cycling", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/nl.png" },
            new CountrySportModel { Country = "Pakistan", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/pk.png" },
            new CountrySportModel { Country = "Portugal", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/pt.png" },
            new CountrySportModel { Country = "Russia", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/ru.png" },
            new CountrySportModel { Country = "Slovakia", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/sk.png" },
            new CountrySportModel { Country = "Sweden", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/se.png" },
            new CountrySportModel { Country = "Thailand", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/th.png" },
            new CountrySportModel { Country = "Ukraine", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/ua.png" },
            new CountrySportModel { Country = "Uruguay", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/uy.png" },
            new CountrySportModel { Country = "USA", Game = "Summer Olympics", Sport = "Road Cycling", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/us.png" },
            new CountrySportModel { Country = "Zimbabwe", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/zw.png" }
        };

        public IActionResult Index(string game = "ALL", string category = "ALL")
        {
            ViewBag.Game = game;
            ViewBag.Category = category;

            var filtered = countries.AsEnumerable();

            if (game != "ALL")
                filtered = filtered.Where(c => c.Game == game);

            if (category != "ALL")
                filtered = filtered.Where(c => c.Category == category);

            return View(filtered.OrderBy(c => c.Country).ToList());
        }
    }
}
