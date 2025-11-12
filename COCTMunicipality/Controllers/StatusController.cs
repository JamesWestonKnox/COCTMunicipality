using COCTMunicipality.Models;
using COCTMunicipality.Services;
using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class StatusController : Controller
    {

        /// <summary>
        /// Service used for managing service requests.
        /// </summary>
        private readonly IssueService issueService;
        public StatusController(IssueService issueService)
        {
            this.issueService = issueService;
        }

        public IActionResult ViewRequestStatus(string searchID = null, string categoryFilter = null)
        {
            ViewData["BodyClass"] = "index-page";

            List<Issue> allIssues = issueService.GetAllIssues();

            var requestStatusService = new RequestStatusService(allIssues);

            // List of requests sorted by status using heap
            List<Issue> requestsByStatus = requestStatusService.FetchAllRequestsByStatus();

            // Search for request by ID using binary search tree
            Issue searchResult = null;
            if (!string.IsNullOrEmpty(searchID) && int.TryParse(searchID, out int id))
            {
                searchResult = requestStatusService.SearchRequestByID(id);
            }

            // List of requests by category using graph.
            List<Issue> requestsByCategory = string.IsNullOrEmpty(categoryFilter) ? allIssues : requestStatusService.FetchRequestsByCategory(categoryFilter);

            // Displays final requests
            var finalRequests = new List<Issue>();
            if (searchResult != null)
            {
                finalRequests.Add(searchResult);
            }
            else if (!string.IsNullOrEmpty(categoryFilter))
            {
                finalRequests = requestsByCategory;
            }
            else
            {
                finalRequests = requestsByStatus;
            }

            ViewData["Requests"] = finalRequests;
            return View();
        }
    }
}

//----------------------------------------------------------------End of File----------------------------------------------------------------\\