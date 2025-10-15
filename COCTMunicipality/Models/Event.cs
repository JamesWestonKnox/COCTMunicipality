namespace COCTMunicipality.Models
{
    /// <summary>
    /// Represents an event in the municipality.
    /// </summary>
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }
}
