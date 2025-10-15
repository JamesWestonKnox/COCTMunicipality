using COCTMunicipality.Services;
using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventService eventService;

        public EventsController()
        {
            eventService = new EventService();
        }

        /// <summary>
        /// Displays the events and announcements page with all events and announcements.
        /// </summary>
        /// <returns>List of all announcements and list of all events</returns>
        public IActionResult ViewEvents()
        {
            ViewData["BodyClass"] = "index-page";
            var events = eventService.FetchAllEvents();
            return View(events);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult SearchEvents(string searchTerm)
        {
            var results = eventService.SearchEvents(searchTerm);
            return Json(results);
        }


    }
}
