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
        private readonly HashSet<string> eventCategories = new HashSet<string>();

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
                    category = "Music",
                    Date = new DateTime(2025, 11, 4),
                    Location = "Cape Town Convention Center"
                },
                new Event
                {
                    EventId = 2,
                    Name = "Cape Town Marathon",
                    category = "Sports",
                    Date = new DateTime(2025, 10, 18),
                    Location = "City Center"
                },
                new Event
                {
                    EventId = 3,
                    Name = "Community Cleanup Day",
                    category = "Volunteer",
                    Date = new DateTime(2025, 10, 23),
                    Location = "District Center"
                },
                new Event
                {
                    EventId = 4,
                    Name = "Kirstenbosch Summer Concert",
                    category = "Concert",
                    Date = new DateTime(2025, 11, 15),
                    Location = "Kirstenbosch Botanical Gardens"
                },
                new Event
                {
                    EventId = 5,
                    Name = "Springboks VS Wallabies Rugby",
                    category = "Sports",
                    Date = new DateTime(2025, 8, 23),
                    Location = "DHL Stadium"
                },
                new Event
                {
                    EventId = 6,
                    Name = "Cape Town Art Fair",
                    category = "Art",
                    Date = new DateTime(2025, 6, 16),
                    Location = "Cape Town Art Gallery"
                },
                new Event
                {
                    EventId = 7,
                    Name = "Heritage Day Braai Festival",
                    category = "Festival",
                    Date = new DateTime(2025, 9, 24),
                    Location = "Greenmarket Square"
                },
                new Event
                {
                    EventId = 8,
                    Name = "Community Safety Workshop",
                    category = "Safety",
                    Date = new DateTime(2026, 2, 5),
                    Location = "Local Community Halls"
                },
                new Event
                {
                    EventId = 9,
                    Name = "Cape Town Green Energy Convention",
                    category = "Enviroment",
                    Date = new DateTime(2025, 11, 23),
                    Location = "Cape Town Convention Center"
                },
                new Event
                {
                    EventId = 10,
                    Name = "Cape Town Book Drive",
                    category = "Education",
                    Date = new DateTime(2025, 6, 6),
                    Location = "City Center"
                },
                new Event
                {
                    EventId = 11,
                    Name = "Cape Town Food and Wine Festival",
                    category = "Food",
                    Date = new DateTime(2025, 5, 23),
                    Location = "Orangezicht Farmers Market"
                },
                new Event
                {
                    EventId = 12,
                    Name = "",
                    category = "Sports",
                    Date = new DateTime(2025, 8, 23),
                    Location = "DHL Stadium"
                },
                new Event
                {
                    EventId = 13,
                    Name = "Cape Town Cycle Tour",
                    category = "Sports",
                    Date = new DateTime(2025, 3, 9),
                    Location = "The Grand Parade"
                },
                new Event
                {
                    EventId = 14,
                    Name = "Feastival",
                    category = "Festival",
                    Date = new DateTime(2025, 9, 27),
                    Location = "Makers Landing V&A Waterfront"
                },
                new Event
                {
                    EventId = 15,
                    Name = "Cape Town Youth Sports Day",
                    category = "Sports",
                    Date = new DateTime(2025, 12, 10),
                    Location = "Athlone Stadium"
                },
            };
            foreach (var ev in exampleEvents)
            {
                events[ev.EventId] = ev;
                eventCategories.Add(ev.category);
            }
        }
    }
}
