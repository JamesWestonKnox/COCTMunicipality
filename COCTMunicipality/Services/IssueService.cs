using COCTMunicipality.Models;


namespace COCTMunicipality.Services
{
    public class IssueService
    {
        private IssueNode head;

        public IssueService()
        {
            head = null;
        }

        public void AddIssue(Issue issue)
        {
            IssueNode newNode = new IssueNode(issue);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                IssueNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public List<Issue> GetAllIssues()
        {
            List<Issue> issues = new List<Issue>();
            IssueNode current = head;

            while (current != null)
            {
                issues.Add(current.Data);
                current = current.Next;
            }
            return issues;
        }

        public int Count()
        {
            int count = 0;
            IssueNode current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
