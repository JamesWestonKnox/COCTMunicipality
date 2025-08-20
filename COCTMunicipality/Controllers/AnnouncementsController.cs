using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class AnnouncementsController : Controller
    {
        public IActionResult ViewAnnouncements()
        {
            ViewData["BodyClass"] = "index-page";
            return View();
        }
    }
}
