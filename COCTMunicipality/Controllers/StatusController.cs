using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
