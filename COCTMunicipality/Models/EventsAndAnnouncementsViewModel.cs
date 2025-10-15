namespace COCTMunicipality.Models
{
    /// <summary>
    /// Viewmodel to hold lists of events and announcements for display purposes.
    /// </summary>
    public class EventsAndAnnouncementsViewModel
    {
        public List<Event> events { get; set; }
        public List<Announcement> announcements { get; set; }
        public List<string> categories { get; set; }
    }
}
