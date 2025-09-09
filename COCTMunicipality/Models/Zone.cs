namespace COCTMunicipality.Models
{
    public class Zone
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }

        public List<Zone> Subzones { get; set; } = new List<Zone>();

        public Zone? Next { get; set; }


    }
}
