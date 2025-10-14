namespace COCTMunicipality.Models
{
    /// <summary>
    /// Represents an announcement in the municipality.
    /// </summary>
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string Name { get; set; }
        public string category { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
