using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_OlympicGames.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Index()
        {
            var favoritesJson = HttpContext.Session.GetString("favorites");
            List<int> ids = string.IsNullOrEmpty(favoritesJson)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(favoritesJson);

            var favorites = SportController.GetAll().Where(s => ids.Contains(s.Id)).ToList();
            return View(favorites);
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("favorites");
            return RedirectToAction("Index");
        }
    }
}
