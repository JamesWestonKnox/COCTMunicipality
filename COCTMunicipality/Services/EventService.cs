using COCTMunicipality.Models;

namespace COCTMunicipality.Services
{
    /// <summary>
    /// Service class used to handle logic related displaying and filtering of events.
    /// </summary>
    public class EventService
    {
        private readonly Dictionary<int, Event> events = new Dictionary<int, Event>();
        private readonly Stack<Event> lastViewedEvents = new Stack<Event>();
        private readonly HashSet<string> eventCategories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Calls method to populate example events.
        /// </summary>
        public EventService()
        {
            FillExampleData();
        }

        /// <summary>
        /// Method to return all events as a list.
        /// </summary>
        /// <returns></returns>
        public List<Event> FetchAllEvents()
        {
            return events.Values.ToList();
        }

        /// <summary>
        /// Method to return all event categories for filtering dropdown menu.
        /// </summary>
        /// <returns></returns>
        public List<string> FetchAllEventCategories()
        {
            return eventCategories.ToList();
        }

        /// <summary>
        ///  Method to search events by name, category or date.
        /// </summary>
        /// <returns></returns>
        public List<Event> SearchEvents(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return FetchAllEvents();
            }
            searchTerm = searchTerm.ToLower();

            return events.Values.Where
                (
                e => e.Name.ToLower().Contains(searchTerm) ||
                e.Category.ToLower().Contains(searchTerm) ||
                e.Date.ToString("yyyy-MM-dd").Contains(searchTerm)
                ).ToList();
        }



        /// <summary>
        /// Method to populate events dictionary with example events.
        /// </summary>
        public void FillExampleData()
        {
            var exampleEvents = new List<Event>
            {
                new Event
                {
                    EventId = 1,
                    Name = "Cape Town Jazz Festival",
                    Category = "Music",
                    Date = new DateTime(2025, 11, 4),
                    Location = "Cape Town Convention Center"
                },
                new Event
                {
                    EventId = 2,
                    Name = "Cape Town Marathon",
                    Category = "Sports",
                    Date = new DateTime(2025, 10, 18),
                    Location = "City Center"
                },
                new Event
                {
                    EventId = 3,
                    Name = "Community Cleanup Day",
                    Category = "Volunteer",
                    Date = new DateTime(2025, 10, 23),
                    Location = "District Center"
                },
                new Event
                {
                    EventId = 4,
                    Name = "Kirstenbosch Summer Concert",
                    Category = "Concert",
                    Date = new DateTime(2025, 11, 15),
                    Location = "Kirstenbosch Botanical Gardens"
                },
                new Event
                {
                    EventId = 5,
                    Name = "Springboks VS Wallabies Rugby",
                    Category = "Sports",
                    Date = new DateTime(2025, 8, 23),
                    Location = "DHL Stadium"
                },
                new Event
                {
                    EventId = 6,
                    Name = "Cape Town Art Fair",
                    Category = "Art",
                    Date = new DateTime(2025, 6, 16),
                    Location = "Cape Town Art Gallery"
                },
                new Event
                {
                    EventId = 7,
                    Name = "Heritage Day Braai Festival",
                    Category = "Festival",
                    Date = new DateTime(2025, 9, 24),
                    Location = "Greenmarket Square"
                },
                new Event
                {
                    EventId = 8,
                    Name = "Community Safety Workshop",
                    Category = "Safety",
                    Date = new DateTime(2026, 2, 5),
                    Location = "Local Community Halls"
                },
                new Event
                {
                    EventId = 9,
                    Name = "Cape Town Green Energy Convention",
                    Category = "Enviroment",
                    Date = new DateTime(2025, 11, 23),
                    Location = "Cape Town Convention Center"
                },
                new Event
                {
                    EventId = 10,
                    Name = "Cape Town Book Drive",
                    Category = "Education",
                    Date = new DateTime(2025, 6, 6),
                    Location = "City Center"
                },
                new Event
                {
                    EventId = 11,
                    Name = "Cape Town Food and Wine Festival",
                    Category = "Food",
                    Date = new DateTime(2025, 5, 23),
                    Location = "Orangezicht Farmers Market"
                },
                new Event
                {
                    EventId = 12,
                    Name = "Cape Town Hiking Day",
                    Category = "Sports",
                    Date = new DateTime(2025, 9, 1),
                    Location = "Table Mountain"
                },
                new Event
                {
                    EventId = 13,
                    Name = "Cape Town Cycle Tour",
                    Category = "Sports",
                    Date = new DateTime(2025, 3, 9),
                    Location = "The Grand Parade"
                },
                new Event
                {
                    EventId = 14,
                    Name = "Feastival",
                    Category = "Festival",
                    Date = new DateTime(2025, 9, 27),
                    Location = "Makers Landing V&A Waterfront"
                },
                new Event
                {
                    EventId = 15,
                    Name = "Cape Town Youth Sports Day",
                    Category = "Sports",
                    Date = new DateTime(2025, 12, 10),
                    Location = "Athlone Stadium"
                },
            };
            foreach (var ev in exampleEvents)
            {
                events[ev.EventId] = ev;
                eventCategories.Add(ev.Category);
            }
        }
    }
}
