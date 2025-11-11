namespace COCTMunicipality.Models
{
    /// <summary>
    /// Enum for strict definition of issue status
    /// </summary>
    public enum Status
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2,
        Rejected = 3

    }

    /// <summary>
    /// Represents a reported issue in the municipality.
    /// </summary>
    public class Issue
    {
        public int IssueID { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaFileName { get; set; }
        public DateTime ReportedAt { get; set; } = DateTime.Now;
        public Status IssueStatus { get; set; } = Status.Pending;
    }
}
