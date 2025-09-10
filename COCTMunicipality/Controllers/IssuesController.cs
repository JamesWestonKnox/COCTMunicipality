using COCTMunicipality.Models;
using COCTMunicipality.Services;
using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class IssuesController : Controller
    {
        /// <summary>
        /// Represents the service used to manage and interact with issues.
        /// </summary>
        private readonly IssueService issueService;

        public IssuesController(IssueService _issueService)
        {
            issueService = _issueService;
        }

        /// <summary>
        /// Displays the issue reporting page with recent issues. 
        /// </summary>
        /// <returns>Report Issue view with recent issues list</returns>
        public IActionResult ReportIssues()
        {
            ViewData["BodyClass"] = "index-page";
            List<Issue> recentIssues = issueService.GetAllIssues().Take(5).ToList();
            return View(recentIssues);
        }

        /// <summary>
        /// Handles the submission of a new issue report.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <param name="media"></param>
        /// <returns>To return issues view</returns>
        [HttpPost]
        public IActionResult SubmitReport(string location, string category, string description, IFormFile media)
        {
            string fileName = null;
            if (media != null && media.Length > 0)
            {
                fileName = media.FileName;
            }

            Issue newIssue = new Issue
            {
                Location = location,
                Category = category,
                Description = description,
                MediaFileName = fileName,
                ReportedAt = DateTime.Now
            };

            issueService.AddIssue(newIssue);
            return RedirectToAction("ReportIssues");
        }
    }
}
