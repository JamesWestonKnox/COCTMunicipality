using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class EventController : Controller
    {

        /// <summary>
        /// Displays the events and announcements page with all events and announcements.
        /// </summary>
        /// <returns>List of all announcements and list of all events</returns>
        public IActionResult ViewAnnouncements()
        {
            ViewData["BodyClass"] = "index-page";
            return View();
        }
    }
}
