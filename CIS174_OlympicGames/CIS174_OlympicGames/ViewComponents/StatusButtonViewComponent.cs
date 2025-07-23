using Microsoft.AspNetCore.Mvc;

namespace CIS174_OlympicGames.ViewComponents
{
    public class StatusButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string status)
        {
            return View("Default", status); //Specify default view name
        }
    }
}
