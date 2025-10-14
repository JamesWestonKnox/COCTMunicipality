namespace COCTMunicipality.Models
{
    // Specify type to either event or announcement
    public enum AnnouncementType
    {
        Event,
        Announcement
    }

    /// <summary>
    /// Represents an announcement or event in the municipality.
    /// </summary>
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string Name { get; set; }
        public string category { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public AnnouncementType Type { get; set; }
    }
}
