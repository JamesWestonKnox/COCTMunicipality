/**
 * StatusController.cs
 *
 * Controller used to handle logic associated with request status page.
 *
 * Reference:
 * OpenAI, 2025. ChatGPT [Computer program]. Version GPT-5.
 * Available at: https://chat.openai.com
 */

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

        public IActionResult ViewRequestStatus(string searchID = null, string categoryFilter = null, string statusFilter = null)
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

            // List requests by status using heap
            List<Issue> requestsByStatusFilter = allIssues;
            Status parsedStatus = Status.Pending;
            if (!string.IsNullOrEmpty(statusFilter) && Enum.TryParse<Status>(statusFilter, out parsedStatus))
            {
                requestsByStatusFilter = requestStatusService.FilterRequestsByStatus(parsedStatus);
            }

            // Displays final requests
            List<Issue> finalRequests = new List<Issue>();
            if (searchResult != null)
            {
                finalRequests.Add(searchResult);
            }
            else if (!string.IsNullOrEmpty(categoryFilter) && !string.IsNullOrEmpty(statusFilter))
            {
                finalRequests = requestsByCategory.Where(r => r.IssueStatus == parsedStatus).ToList();
            }
            else if (!string.IsNullOrEmpty(statusFilter))
            {
                finalRequests = requestsByStatusFilter;
            }
            else if (!string.IsNullOrEmpty(categoryFilter))
            {
                finalRequests = requestsByCategory;
            }
            else
            {
                finalRequests = requestsByStatus;
            }

            return View(finalRequests);
        }
    }
}

//----------------------------------------------------------------End of File----------------------------------------------------------------\\