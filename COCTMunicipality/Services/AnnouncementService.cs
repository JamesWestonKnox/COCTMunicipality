using COCTMunicipality.Models;

namespace COCTMunicipality.Services
{
    /// <summary>
    /// Service class used to handle logic related to displaying announcements.
    /// </summary>
    public class AnnouncementService
    {
        private readonly Dictionary<int, Announcement> announcements = new Dictionary<int, Announcement>();

        /// <summary>
        /// Calls method to populate example announcements.
        /// </summary>
        public AnnouncementService()
        {
            FillExampleAnnouncementData();
        }

        /// <summary>
        /// Method to return all announcements as a list.
        /// </summary>
        /// <returns>List of announcements</returns>
        public List<Announcement> FetchAllAnnouncements()
        {
            return announcements.Values.ToList();
        }

        /// <summary>
        /// Method to populate example announcements.
        /// </summary>
        public void FillExampleAnnouncementData()
        {
            var exampleAnnouncements = new List<Announcement>
            {
                new Announcement
                {
                    AnnouncementId = 1,
                    Name = "Road Closure",
                    Location = "Loop Street",
                    Description = "Road closure from 15th to 16th October 2025",
                    Category = "Infrastructure",
                    Date = new DateTime(2025, 10, 11)
                },
                new Announcement
                {
                    AnnouncementId = 2,
                    Name = "Water Outage",
                    Location = "Hout Bay",
                    Description = "Main water pipe burst, expect outage",
                    Category = "Utilities",
                    Date = new DateTime(2025, 10, 7)
                },
                new Announcement
                {
                    AnnouncementId = 3,
                    Name = "Power Outage",
                    Location = "Claremont",
                    Description = "Scheduled power outage for maintenance",
                    Category = "Utilities",
                    Date = new DateTime(2025, 10, 9)

                },
                new Announcement
                {
                    AnnouncementId = 4,
                    Name = "Railway Disruption",
                    Location = "City Center",
                    Description = "City Railway closed for repairs",
                    Category = "Transport",
                    Date = new DateTime(2025, 10, 12)
                },
            };
            foreach (var announcement in exampleAnnouncements)
            {
                announcements[announcement.AnnouncementId] = announcement;
            }
        }
    }
}
