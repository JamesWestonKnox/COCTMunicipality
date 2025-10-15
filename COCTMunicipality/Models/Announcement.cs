namespace COCTMunicipality.Models
{
    /// <summary>
    /// Represents an announcement posted by the municipality.
    /// </summary>
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

    }
}
