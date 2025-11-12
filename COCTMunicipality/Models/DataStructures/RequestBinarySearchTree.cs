/**
 * RequestBinarySearchTree.cs
 *
 * This file implements a Binary Search Tree (BST) used to organize and search for service requests by their unique ID.
 *
 * Reference:
 * OpenAI, 2025. ChatGPT [Computer program]. Version GPT-5.
 * Available at: https://chat.openai.com
 */
namespace COCTMunicipality.Models.DataStructures
{
    /// <summary>
    /// Binary search tree for looking up and traversing Requests
    /// </summary>
    public class RequestBinarySearchTree
    {
        // Defines node structure
        public class Node
        {
            public Issue Issue;
            public Node Left, Right;
            public Node(Issue issue) => Issue = issue;
        }

        private Node root;

        /// <summary>
        /// Insert new service request into the tree
        /// </summary>
        /// <param name="issue">The service request</param>
        public void InsertRequest(Issue issue)
        {
            if (root == null)
            {
                root = new Node(issue);
                return;
            }

            Node current = root;
            while (true)
            {
                if (issue.IssueID < current.Issue.IssueID)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(issue);
                        break;
                    }
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(issue);
                        break;
                    }
                    current = current.Right;
                }
            }
        }

        /// <summary>
        /// Search for a request using IssueID
        /// </summary>
        /// <param name="requestID">ID of request</param>
        /// <returns>Request matching ID</returns>
        public Issue SearchRequest(int requestID)
        {
            Node current = root;
            while (current != null)
            {
                if (requestID < current.Issue.IssueID)
                {
                    return current.Issue;
                }
                current = requestID < current.Issue.IssueID ? current.Left : current.Right;
            }
            return null;
        }

        /// <summary>
        /// Method to find all requests and return in order
        /// </summary>
        /// <returns>Ordered (By ID) list of service requests</returns>
        public List<Issue> Traversal()
        {
            var result = new List<Issue>();
            Traverse(root, result);
            return result;
        }

        private void Traverse(Node node, List<Issue> requestList)
        {
            if (node == null)
            {
                return;
            }
            Traverse(node.Left, requestList);
            requestList.Add(node.Issue);
            Traverse(node.Right, requestList);
        }
    }
}

//----------------------------------------------------------------End of File----------------------------------------------------------------\\