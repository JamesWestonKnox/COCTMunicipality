using COCTMunicipality.Models;

namespace COCTMunicipality.Services
{
    public class IssueService
    {
        /// <summary>
        /// Represents the head node of the linked list of issues.
        /// </summary>
        private IssueNode head;

        // Used to auto increment issue id 
        private int nextId = 1;

        /// <summary>
        /// Initializes a new instance of the issue service with an empty linked list.
        /// </summary>
        public IssueService()
        {
            head = null;
        }

        /// <summary>
        /// Adds a new issue to the end of the issue list.
        /// </summary>
        /// <param name="issue">The issue to add.</param>
        public void AddIssue(Issue issue)
        {
            issue.IssueID = nextId++;
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

        /// <summary>
        /// Retrieves all issues in the linked list.
        /// </summary>
        /// <returns>List<Issues></returns>
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

        /// <summary>
        /// Counts the total number of nodes in the linked list.
        /// </summary>
        /// <returns>The total number of nodes in the linked list. Returns 0 if the list is empty.</returns>
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
