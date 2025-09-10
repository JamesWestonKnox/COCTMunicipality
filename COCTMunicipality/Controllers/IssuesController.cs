using COCTMunicipality.Models;
using COCTMunicipality.Services;
using Microsoft.AspNetCore.Mvc;

namespace COCTMunicipality.Controllers
{
    public class IssuesController : Controller
    {

        private static IssueService issueService = new IssueService();

        public IActionResult ReportIssues()
        {
            ViewData["BodyClass"] = "index-page";
            List<Issue> recentIssues = issueService.GetAllIssues().Take(5).ToList();
            return View(recentIssues);
        }

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
