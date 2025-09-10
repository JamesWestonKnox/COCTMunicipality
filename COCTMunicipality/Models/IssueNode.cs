namespace COCTMunicipality.Models
{
    /// <summary>
    /// Represents a node in a linked list of issues.
    /// </summary>
    public class IssueNode
    {
        public Issue Data { get; set; }
        public IssueNode Next { get; set; }

        public IssueNode(Issue data)
        {
            Data = data;
            Next = null;
        }
    }
}
