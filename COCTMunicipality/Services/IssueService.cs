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
            SeedIssues();
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

        /// <summary>
        /// Seed example issues
        /// </summary>
        private void SeedIssues()
        {
            var exampleIssues = new List<Issue>
            {
                new Issue { Category = "Sanitation", Location = "City Bowl", Description = "Overflowing garbage bins near market", IssueStatus = Status.Pending, ReportedAt = DateTime.Now.AddDays(-3) },
                new Issue { Category = "Roads & Transport", Location = "Atlantic Seaboard", Description = "Potholes along Main Road", IssueStatus = Status.InProgress, ReportedAt = DateTime.Now.AddDays(-5) },
                new Issue { Category = "Utilities", Location = "Khayelitsha", Description = "Water supply disruption reported", IssueStatus = Status.Completed, ReportedAt = DateTime.Now.AddDays(-10) },
                new Issue { Category = "Health & Safety", Location = "Mitchells Plain", Description = "Street lighting not working in alley", IssueStatus = Status.Pending, ReportedAt = DateTime.Now.AddDays(-1) },
                new Issue { Category = "Parks & Recreation", Location = "Southern Suburbs", Description = "Broken swing at community park", IssueStatus = Status.InProgress, ReportedAt = DateTime.Now.AddDays(-2) },
                new Issue { Category = "Housing & Buildings", Location = "Northern Suburbs", Description = "Graffiti on public building walls", IssueStatus = Status.Completed, ReportedAt = DateTime.Now.AddDays(-8) },
                new Issue { Category = "Animal Control", Location = "West Coast", Description = "Stray dogs near residential area", IssueStatus = Status.Pending, ReportedAt = DateTime.Now.AddDays(-6) },
                new Issue { Category = "Environmental Issues", Location = "False Bay", Description = "Illegal dumping on the beach", IssueStatus = Status.InProgress, ReportedAt = DateTime.Now.AddDays(-4) },
                new Issue { Category = "Fire & Emergency Services", Location = "Helderberg", Description = "Abandoned building fire risk", IssueStatus = Status.Pending, ReportedAt = DateTime.Now.AddDays(-7) },
                new Issue { Category = "Law Enforcement & Security", Location = "Table Bay", Description = "Suspicious activity reported in park", IssueStatus = Status.Completed, ReportedAt = DateTime.Now.AddDays(-12) }
            };

            foreach (var issue in exampleIssues)
            {
                AddIssue(issue);
            }
        }
    }
}
