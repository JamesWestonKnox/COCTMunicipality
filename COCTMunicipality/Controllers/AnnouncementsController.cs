using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class AnnouncementsController : Controller
    {

        /// <summary>
        /// Displays the announcements page with all announcements.
        /// </summary>
        /// <returns>List of all announcements</returns>
        public IActionResult ViewAnnouncements()
        {
            ViewData["BodyClass"] = "index-page";
            return View();
        }
    }
}
