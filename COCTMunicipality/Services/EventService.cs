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
            FillExampleEventData();
        }

        /// <summary>
        /// Method to return all events as a list.
        /// </summary>
        /// <returns>List of events</returns>
        public List<Event> FetchAllEvents()
        {
            return events.Values.ToList();
        }

        /// <summary>
        /// Method to return all event categories for filtering dropdown menu.
        /// </summary>
        /// <returns>List of event categories</returns>
        public List<string> FetchAllEventCategories()
        {
            return eventCategories.ToList();
        }

        /// <summary>
        ///  Method to search events by name, category or date.
        /// </summary>
        /// <returns>List of mathcing events</returns>
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
        /// Method to add last 3 viewed events to a stack.
        /// </summary>
        public void AddToLastViewedEvents(int eventId)
        {
            if (!events.TryGetValue(eventId, out var ev)) return;

            var tempList = lastViewedEvents.ToList();

            tempList.RemoveAll(e => e.EventId == eventId);

            lastViewedEvents.Clear();

            lastViewedEvents.Push(ev);

            int count = 0;
            foreach (var item in tempList)
            {
                if (count >= 2) break;
                lastViewedEvents.Push(item);
                count++;
            }
        }

        /// <summary>
        /// Method to return last 3 viewed events as a list.
        /// </summary>
        /// <returns>List of up to 3 events</returns>
        public List<Event> GetLastViewedEvents()
        {
            return lastViewedEvents.ToList();
        }

        /// <summary>
        /// Method to populate events dictionary with example events.
        /// </summary>
        public void FillExampleEventData()
        {
            var exampleEvents = new List<Event>
            {
                new Event
                {
                    EventId = 1,
                    Name = "Cape Town Jazz Festival",
                    Category = "Music",
                    Date = new DateTime(2025, 11, 4),
                    Location = "Cape Town Convention Center",
                    Description = "The Cape Town Jazz Festival is an annual music festival held in Cape Town, South Africa. It is one of the largest jazz festivals in Africa and features a diverse lineup of local and international jazz artists."
                },
                new Event
                {
                    EventId = 2,
                    Name = "Cape Town Marathon",
                    Category = "Sports",
                    Date = new DateTime(2025, 10, 18),
                    Location = "City Center",
                    Description = "Cape Town annual marathon"
                },
                new Event
                {
                    EventId = 3,
                    Name = "Community Cleanup Day",
                    Category = "Volunteer",
                    Date = new DateTime(2025, 10, 23),
                    Location = "District Center",
                    Description = "Join us for a community cleanup day to help keep our city clean and beautiful!"
                },
                new Event
                {
                    EventId = 4,
                    Name = "Kirstenbosch Summer Concert",
                    Category = "Concert",
                    Date = new DateTime(2025, 11, 15),
                    Location = "Kirstenbosch Botanical Gardens",
                    Description = "Enjoy live music in the beautiful Kirstenbosch Botanical Gardens."
                },
                new Event
                {
                    EventId = 5,
                    Name = "Springboks VS Wallabies Rugby",
                    Category = "Sports",
                    Date = new DateTime(2025, 8, 23),
                    Location = "DHL Stadium",
                    Description = "Watch the thrilling rugby match between the Springboks and the Wallabies!"
                },
                new Event
                {
                    EventId = 6,
                    Name = "Cape Town Art Fair",
                    Category = "Art",
                    Date = new DateTime(2025, 6, 16),
                    Location = "Cape Town Art Gallery",
                    Description = "Explore contemporary art from local and international artists at the Cape Town Art Fair."
                },
                new Event
                {
                    EventId = 7,
                    Name = "Heritage Day Braai Festival",
                    Category = "Festival",
                    Date = new DateTime(2025, 9, 24),
                    Location = "Greenmarket Square",
                    Description = "Celebrate Heritage Day with a traditional South African braai festival!"
                },
                new Event
                {
                    EventId = 8,
                    Name = "Community Safety Workshop",
                    Category = "Safety",
                    Date = new DateTime(2026, 2, 5),
                    Location = "Local Community Halls",
                    Description = "Join us for a workshop on community safety and crime prevention strategies."
                },
                new Event
                {
                    EventId = 9,
                    Name = "Cape Town Green Energy Convention",
                    Category = "Enviroment",
                    Date = new DateTime(2025, 11, 23),
                    Location = "Cape Town Convention Center",
                    Description = "Join industry leaders and experts to discuss the latest trends and innovations in green energy."
                },
                new Event
                {
                    EventId = 10,
                    Name = "Cape Town Book Drive",
                    Category = "Education",
                    Date = new DateTime(2025, 6, 6),
                    Location = "City Center",
                    Description = "Donate your gently used books to support literacy and education in our community."
                },
                new Event
                {
                    EventId = 11,
                    Name = "Cape Town Food and Wine Festival",
                    Category = "Food",
                    Date = new DateTime(2025, 5, 23),
                    Location = "Orangezicht Farmers Market",
                    Description = "Experience the best of Cape Town's culinary scene with food and wine tastings from top chefs and wineries."
                },
                new Event
                {
                    EventId = 12,
                    Name = "Cape Town Hiking Day",
                    Category = "Sports",
                    Date = new DateTime(2025, 9, 1),
                    Location = "Table Mountain",
                    Description = "Join us for a day of hiking and exploring the beautiful trails of Table Mountain."
                },
                new Event
                {
                    EventId = 13,
                    Name = "Cape Town Cycle Tour",
                    Category = "Sports",
                    Date = new DateTime(2025, 3, 9),
                    Location = "The Grand Parade",
                    Description = "Annual cycling Race"
                },
                new Event
                {
                    EventId = 14,
                    Name = "Feastival",
                    Category = "Festival",
                    Date = new DateTime(2025, 9, 27),
                    Location = "Makers Landing V&A Waterfront",
                    Description = "A food festival showcasing local cuisine and international flavors."
                },
                new Event
                {
                    EventId = 15,
                    Name = "Cape Town Youth Sports Day",
                    Category = "Sports",
                    Date = new DateTime(2025, 12, 10),
                    Location = "Athlone Stadium",
                    Description = "A day dedicated to promoting youth sports and healthy living."
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