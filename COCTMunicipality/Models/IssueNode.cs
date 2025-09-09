namespace COCTMunicipality.Models
{
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
