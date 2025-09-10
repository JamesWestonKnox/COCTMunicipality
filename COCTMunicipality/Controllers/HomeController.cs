using COCTMunicipality.Models;
using COCTMunicipality.Services;
using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    /// <summary>
    /// Represents the controller responsible for handling requests to the home page of the application.
    /// </summary>
    public class HomeController : Controller
    {

        private readonly IssueService issueService;
        public HomeController(IssueService _issueService)
        {
            issueService = _issueService;
        }

        /// <summary>
        /// Displays the home page with a summary of recent issues and the total issue count.
        /// </summary>
        public IActionResult Index()
        {
            ViewData["BodyClass"] = "index-page";

            // Fetch the 5 most recent issues
            var recentIssues = issueService.GetAllIssues().OrderByDescending(i => i.ReportedAt).Take(5).ToList();

            // Prepare the view model
            var model = new HomeViewModel
            {
                RecentIssues = recentIssues,
                TotalIssues = issueService.Count()
            };

            return View(model);
        }

    }

    /// <summary>
    /// Represents the data model for the home view, including recent issues and their total count.
    /// </summary>
    public class HomeViewModel
    {
        public List<Issue> RecentIssues { get; set; } = new List<Issue>();
        public int TotalIssues { get; set; } = 0;
    }
}
