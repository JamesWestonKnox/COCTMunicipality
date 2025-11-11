using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult ViewRequestStatus()
        {
            ViewData["BodyClass"] = "index-page";
            return View();
        }
    }
}
