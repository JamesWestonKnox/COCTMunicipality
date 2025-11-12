/**
 * RequestStatusService.cs
 *
 * Service class used to populate and initilize data structures for the request status page.
 *
 * Reference:
 * OpenAI, 2025. ChatGPT [Computer program]. Version GPT-5.
 * Available at: https://chat.openai.com
 */

using COCTMunicipality.Models;
using COCTMunicipality.Models.DataStructures;

namespace COCTMunicipality.Services
{
    public class RequestStatusService
    {
        private readonly RequestBinarySearchTree requestBinarySearchTree = new RequestBinarySearchTree();
        private readonly RequestHeap requestHeap = new RequestHeap();
        private readonly RequestGraph requestGraph = new RequestGraph();

        public RequestStatusService(List<Issue> issues)
        {
            // Adds all issues to each data structure
            foreach (var issue in issues)
            {
                requestBinarySearchTree.InsertRequest(issue);
                requestHeap.Insert(issue);
                requestGraph.AddRequestNode(issue);
            }
        }

        public Issue SearchRequestByID(int id) => requestBinarySearchTree.SearchRequest(id);

        public List<Issue> FetchAllRequestsByStatus() => requestHeap.GetAllRequestsOrderedByStatus();

        public List<Issue> FilterRequestsByStatus(Status status) => requestHeap.FilterRequestsByStatus(status);
        public List<Issue> FetchRequestsByCategory(string category) => requestGraph.FetchRequestByCategory(category);

    }
}

//----------------------------------------------------------------End of File----------------------------------------------------------------\\
