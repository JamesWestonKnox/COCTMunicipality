# City of Cape Town Municipality Web App
**Members:**
- James Knox (ST10048826)

**GitHub Repository:**
- awdwa

**Youtube Video:**
- https://youtu.be/gcpU2uLwywY

---

## Application Overview
The City of Cape Town Municipality Web App is a platform built to allow Cape Town residents to:

- Report issues and submit service requests.
- Track the status of submitted service requests.
- View all upcoming events and important announcements.

---

## Application Features
- Submit issues with location, category, description, and optional media.
- List and filter through submitted issues to track status.
- Dynamic progress bar shows form completion.
- Find and sort through events and announcments.

---

## Technologies Used
**Backend:** ASP.NET Core MVC

**Frontend:** Razor, HTML, CSS, Bootstrap

**JavaScript:** Dynamic progress bar

---

## Data Structures Implemented
- **Binary Search Tree (BST)**
  - Used to organize and search for service requests using their unique request ID.
  - Enhances performance through quicker sorting and fetching of service requests with their ID.
- **Min-Heap**
  - Used to sort and filter service requests based on their status (priority).
  - Allows for tracking and display of urgent or most common status.
- **Graph**
  - Implemented to find relationships between service requests and their categories.
  - Provides quick search and filtering of requests belonging to the same category.

---

## Changelog
- Added page to view status of submitted service requests.
- Implemented advanced data structures to aid in the display and filtering of service requests.
- Pre-seeded 10 initial service requests.

---

## Setup Application
- Clone the GitHub repository.
- Open in Visual Studio.
- Ensure all NuGet packages are updated.
- Run the application using the green play button (CTRL + F5)

---

## Using the Application
- **Submitting a Service Request:**
  - Navigate to Report Issues page.
  - Select issue location and category.
  - Add issue description.
  - Add optional media attachment.
  - Submit
- **Tracking Service Requests:**
  - Navigate to Request Status page.
  - Search for request using Request ID, category or status.
  - Click search or reset.
- **View Events & Announcements:**
  - Navigate to Events & Announcements page.
  - Search by name, category or date.
  - Sort by name or date.
  - Click back or reset. 

---
