using COCTMunicipality.Services;
using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class AnnouncementsController : Controller
    {

        /// <summary>
        /// Represents the service used to manage and interact with announcements.
        /// </summary>
        private readonly AnnouncementService announcementService;

        public AnnouncementsController(AnnouncementService _announcementService)
        {
            announcementService = _announcementService;
        }

        /// <summary>
        /// Displays the announcements page with all announcements.
        /// </summary>
        /// <returns>List of all announcements</returns>
        public IActionResult ViewAnnouncements()
        {
            ViewData["BodyClass"] = "index-page";
            List<Announcement> allAnnouncements = announcementService.GetAllAnnouncements();
            return View(allAnnouncements);
        }
    }
}
