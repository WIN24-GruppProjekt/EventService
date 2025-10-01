# EventService

A .NET 9.0 Web API for managing events with double booking prevention.

## Features

- Event CRUD operations with trainer assignments
- Double booking prevention using LocationId and RoomId
- Time-based filtering (upcoming events, date ranges)
- ID-based references for Location, Room, and Trainer
- Clean architecture with Application, Persistence, and Presentation layers

## Tech Stack

- .NET 9.0
- ASP.NET Core Web API
- Entity Framework Core 9.0
- SQL Server
- Swagger/OpenAPI

## Setup

### Prerequisites

- .NET 9.0 SDK
- SQL Server (LocalDB, Express, or full instance)

### Installation

1. Clone the repository

```bash
git clone <your-repo-url>
cd EventService
```

2. Configure database connection

```bash
# Copy template and update connection string
cp Presentation/appsettings.template.json Presentation/appsettings.json
```

Edit `appsettings.json` with your SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EventServiceDb;Trusted_Connection=True;"
  }
}
```

3. Apply database migrations

```bash
dotnet ef database update --project Persistence --startup-project Presentation
```

4. Run the API

```bash
dotnet run --project Presentation
```

API available at `http://localhost:5000` • Swagger at `/swagger`

## API Endpoints

| Method | Endpoint                 | Description              |
| ------ | ------------------------ | ------------------------ |
| GET    | `/api/events`            | Get all events           |
| GET    | `/api/events/upcoming`   | Get upcoming events      |
| GET    | `/api/events/{id}`       | Get event by ID          |
| POST   | `/api/events`            | Create event             |
| PUT    | `/api/events/{id}`       | Update event             |
| DELETE | `/api/events/{id}`       | Delete event             |
| GET    | `/api/events/date-range` | Get events by date range |

## Event Schema

```json
{
  "title": "Morning Yoga",
  "description": "Relaxing yoga session",
  "startTime": "2025-10-01T09:00:00Z",
  "endTime": "2025-10-01T10:00:00Z",
  "locationId": "building-a",
  "roomId": 101,
  "trainerId": "trainer-123"
}
```

**Validation:**

- Title: max 200 characters (required)
- Description: max 1000 characters
- LocationId: max 100 characters (required)
- TrainerId: max 100 characters (required)

## Double Booking Prevention

Prevents overlapping events in the same location and room:

- Returns HTTP 409 Conflict when booking conflicts detected
- Checks LocationId + RoomId + time overlap
- Excludes current event when updating

## Project Structure

```
EventService/
├── Application/      # Business logic, services, DTOs
├── Persistence/      # EF Core, entities, repositories
└── Presentation/     # API controllers, configuration
```
