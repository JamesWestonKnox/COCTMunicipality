/**
 * RequestGraph.cs
 *
 * Implementes graph data structure to group and connect service requests based on category.
 *
 * Reference:
 * OpenAI, 2025. ChatGPT [Computer program]. Version GPT-5.
 * Available at: https://chat.openai.com
 */
namespace COCTMunicipality.Models.DataStructures
{
    /// <summary>
    /// Node representing a request in the graph
    /// </summary>
    public class RequestGraphNode
    {
        public Issue Issue { get; set; }
        public List<RequestGraphNode> NeighborNodes { get; set; } = new List<RequestGraphNode>();

        public RequestGraphNode(Issue issue)
        {
            Issue = issue;
        }
    }

    /// <summary>
    /// Graph data strucuture connecting requests through shared categories
    /// </summary>
    public class RequestGraph
    {
        private List<RequestGraphNode> requests = new List<RequestGraphNode>();

        /// <summary>
        /// Adds a new requst to the graph
        /// Connects to other nodes with same category
        /// </summary>
        /// <param name="issue">Request to add</param>
        /// <returns>Request node represting request</returns>
        public RequestGraphNode AddRequestNode(Issue issue)
        {
            var requestNode = new RequestGraphNode(issue);
            requests.Add(requestNode);

            foreach (var n in requests)
            {
                if (n != null && n.Issue.Category == issue.Category)
                {
                    n.NeighborNodes.Add(requestNode);
                    requestNode.NeighborNodes.Add(n);
                }
            }
            return requestNode;
        }

        /// <summary>
        /// Fetches all requests in a given category.
        /// Utilizes Breadth-First-Search Traversal method.
        /// </summary>
        /// <param name="category">Category to search for</param>
        /// <returns>List of requests in category</returns>
        public List<Issue> FetchRequestByCategory(string category)
        {
            // Hash set to track visited nodes
            var visited = new HashSet<RequestGraphNode>();

            // Queue to track next nodes to search
            var queue = new Queue<RequestGraphNode>();

            // List of requests matching category
            var result = new List<Issue>();

            // Begins BFS search
            foreach (var n in requests.Where(n => n.Issue.Category == category))
            {
                if (!visited.Contains(n))
                {
                    queue.Enqueue(n);
                    visited.Add(n);

                    while (queue.Count > 0)
                    {
                        var current = queue.Dequeue();
                        result.Add(current.Issue);

                        foreach (var neighborNode in current.NeighborNodes)
                        {
                            if (!visited.Contains(neighborNode) && neighborNode.Issue.Category == category)
                            {
                                queue.Enqueue(neighborNode);
                                visited.Add(neighborNode);
                            }
                        }
                    }
                }
            }

            return result;
        }

    }
}

//----------------------------------------------------------------End of File----------------------------------------------------------------\\