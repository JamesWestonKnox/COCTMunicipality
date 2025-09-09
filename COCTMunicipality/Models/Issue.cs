namespace COCTMunicipality.Models
{
    public class Issue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaFileName { get; set; }
        public DateTime ReportedAt { get; set; } = DateTime.Now;
    }
}
