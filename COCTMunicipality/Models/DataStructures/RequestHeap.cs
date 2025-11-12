/**
 * RequestHeap.cs
 *
 * This file uses  MinHeap to fetch and filter requests by their status using the IssueStatus ENUM
 *
 * Reference:
 * OpenAI, 2025. ChatGPT [Computer program]. Version GPT-5.
 * Available at: https://chat.openai.com
 */
namespace COCTMunicipality.Models.DataStructures
{
    /// <summary>
    /// Request heap used to filter by status
    /// </summary>
    public class RequestHeap
    {
        private readonly List<Issue> heap = new List<Issue>();
        public int Count => heap.Count;

        /// <summary>
        /// Insert request into the heap
        /// </summary>
        /// <param name="issue">Request to insert</param>
        public void Insert(Issue issue)
        {
            heap.Add(issue);
            HeapifyUp(heap.Count - 1);
        }

        /// <summary>
        /// Fetches a list of all requests ordered by status (pending = 0 -> InProgress = 1 -> Completed = 2 -> Rejected = 3)
        /// </summary>
        /// <returns>List of requests</returns>
        public List<Issue> GetAllRequestsOrderedByStatus()
        {
            var sortedRequests = new List<Issue>(heap);
            sortedRequests.Sort((a, b) => a.IssueStatus.CompareTo(b.IssueStatus));
            return sortedRequests;
        }

        /// <summary>
        /// Fetches a list of all requests with a specific status
        /// </summary>
        /// <param name="status">Status to look for</param>
        /// <returns>List of requests with specific status</returns>
        public List<Issue> FilterRequestsByStatus(Status status)
        {
            return heap.FindAll(i => i.IssueStatus == status);
        }

        /// <summary>
        /// Ensures heap order is maintained by comparing new requests with other nodes.
        /// </summary>
        /// <param name="index">New request index</param>
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (heap[index].IssueStatus >= heap[parentIndex].IssueStatus)
                {
                    break;
                }
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        /// <summary>
        /// Swaps two requests using their index
        /// </summary>
        /// <param name="i">First request index</param>
        /// <param name="j">Second request index</param>
        private void Swap(int i, int j)
        {
            (heap[i], heap[j]) = (heap[j], heap[i]);
        }
    }
}

//----------------------------------------------------------------End of File----------------------------------------------------------------\\