using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class AnnouncementsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
