using COCTMunicipality.Services;
using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class EventsController : Controller
    {
        /// <summary>
        /// Represents the service used to manage and interact with events.
        /// </summary>
        private readonly EventService eventService;

        public EventsController(EventService _eventService)
        {
            eventService = _eventService;
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
        /// Searches for events using searchTerm parameter input
        /// Passes to script in ViewEvents.cshtml
        /// </summary>
        /// <returns>JSON array of events</returns>
        [HttpGet]
        public JsonResult SearchEvents(string searchTerm)
        {
            var results = eventService.SearchEvents(searchTerm);
            return Json(results);
        }



    }
}
