using CIS174_OlympicGames.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_OlympicGames.Models
{
    public class SportIndexViewModel
    {
        public string Game { get; set; } = "ALL";
        public string Category { get; set; } = "ALL";
        public List<CountrySportModel> FilteredSports { get; set; } = new();
    }
}
