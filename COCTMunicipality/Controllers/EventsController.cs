using COCTMunicipality.Models;

using COCTMunicipality.Services;
using Microsoft.AspNetCore.Mvc;
namespace COCTMunicipality.Controllers
{
    public class EventsController : Controller
    {
        /// <summary>
        /// Represents the services used to manage and interact with events and announcements.
        /// </summary>
        private readonly EventService eventService;
        private readonly AnnouncementService announcementService;
        public EventsController(EventService _eventService, AnnouncementService _announcementService)
        {
            eventService = _eventService;
            announcementService = _announcementService;
        }

        /// <summary>
        /// Displays the events and announcements page with all events and announcements.
        /// </summary>
        /// <returns>List of all announcements and list of all events</returns>
        public IActionResult ViewEvents()
        {
            ViewData["BodyClass"] = "index-page";
            var viewModel = new EventsAndAnnouncementsViewModel
            {
                events = eventService.FetchAllEvents(),
                announcements = announcementService.FetchAllAnnouncements()
            };
            return View(viewModel);
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

        /// <summary>
        /// Adds an event to the list of recently viewed events.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddLastViewedEvent(int id)
        {
            eventService.AddToLastViewedEvents(id);
            return Ok();
        }

        /// <summary>
        /// Fetches the last 3 viewed events and returns them as JSON.
        /// </summary>
        /// <returns>JSON array of recent events</returns>
        [HttpGet]
        public JsonResult GetLastViewedEvent()
        {
            var recent = eventService.GetLastViewedEvents();
            return Json(recent);
        }


    }
}
