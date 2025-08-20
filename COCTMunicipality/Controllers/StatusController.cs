using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult ViewStatus()
        {
            ViewData["BodyClass"] = "index-page";
            return View();
        }
    }
}
