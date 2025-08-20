using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class IssuesController : Controller
    {
        public IActionResult ReportIssues()
        {
            ViewData["BodyClass"] = "index-page";
            return View();
        }
    }
}
