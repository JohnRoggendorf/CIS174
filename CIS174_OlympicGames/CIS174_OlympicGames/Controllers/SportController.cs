using Microsoft.AspNetCore.Mvc;
using CIS174_OlympicGames.Models;
using System.Text.Json;

namespace CIS174_OlympicGames.Controllers
{
    public class SportController : Controller
    {
        private static List<CountrySportModel> countries = new List<CountrySportModel>
        {
            new CountrySportModel { Id = 1, Country = "Austria", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/at.png" },
            new CountrySportModel { Id = 2, Country = "Brazil", Game = "Summer Olympics", Sport = "Road Cycling", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/br.png" },
            new CountrySportModel { Id = 3, Country = "Canada", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/ca.png" },
            new CountrySportModel { Id = 4, Country = "China", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/cn.png" },
            new CountrySportModel { Id = 5, Country = "Cyprus", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/cy.png" },
            new CountrySportModel { Id = 6, Country = "Finland", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/fi.png" },
            new CountrySportModel { Id = 7, Country = "France", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/fr.png" },
            new CountrySportModel { Id = 8, Country = "Germany", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/de.png" },
            new CountrySportModel { Id = 9, Country = "Great Britain", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/gb.png" },
            new CountrySportModel { Id = 10, Country = "Italy", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/it.png" },
            new CountrySportModel { Id = 11, Country = "Jamaica", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/jm.png" },
            new CountrySportModel { Id = 12, Country = "Japan", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/jp.png" },
            new CountrySportModel { Id = 13, Country = "Mexico", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/mx.png" },
            new CountrySportModel { Id = 14, Country = "Netherlands", Game = "Summer Olympics", Sport = "Cycling", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/nl.png" },
            new CountrySportModel { Id = 15, Country = "Pakistan", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/pk.png" },
            new CountrySportModel { Id = 16, Country = "Portugal", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/pt.png" },
            new CountrySportModel { Id = 17, Country = "Russia", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/ru.png" },
            new CountrySportModel { Id = 18, Country = "Slovakia", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/sk.png" },
            new CountrySportModel { Id = 19, Country = "Sweden", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/se.png" },
            new CountrySportModel { Id = 20, Country = "Thailand", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/th.png" },
            new CountrySportModel { Id = 21, Country = "Ukraine", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/ua.png" },
            new CountrySportModel { Id = 22, Country = "Uruguay", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagPath = "https://flagcdn.com/w80/uy.png" },
            new CountrySportModel { Id = 23, Country = "USA", Game = "Summer Olympics", Sport = "Road Cycling", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/us.png" },
            new CountrySportModel { Id = 24, Country = "Zimbabwe", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagPath = "https://flagcdn.com/w80/zw.png" }
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

        public IActionResult Details(int id)
        {
            var sport = countries.FirstOrDefault(c => c.Id == id);
            if (sport == null) return NotFound();
            return View(sport);
        }

        public IActionResult AddToFavorites(int id)
        {
            var favorites = HttpContext.Session.GetString("favorites");
            List<int> favoriteIds = string.IsNullOrEmpty(favorites)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(favorites);

            if (!favoriteIds.Contains(id))
                favoriteIds.Add(id);

            HttpContext.Session.SetString("favorites", JsonSerializer.Serialize(favoriteIds));

            return RedirectToAction("Index");
        }

        public static List<CountrySportModel> GetAll() => countries;
    }
}
