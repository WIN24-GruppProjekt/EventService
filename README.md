# EventService

A .NET 9.0 Web API for managing events with double booking prevention.

## ✨ Features

- **Event Management** - Create, read, update, and delete events with trainer assignments
- **Double Booking Prevention** - Automatically prevents conflicting bookings using LocationId and RoomId
- **Time-based Filtering** - Get upcoming events and events by date range
- **ID-based References** - Uses IDs for Location, Room, and Trainer (ready for microservice integration)
- **Clean Architecture** - Separation of concerns with Application, Persistence, and Presentation layers

## 🚀 Quick Start

### Prerequisites

- .NET 9.0 SDK

### Run the API

```bash
git clone <your-repo-url>
cd EventService
dotnet restore
dotnet run --project Presentation
```

The API will be available at `http://localhost:5000` with Swagger documentation at `/swagger`.

## 📚 API Endpoints

| Method   | Endpoint                 | Description              |
| -------- | ------------------------ | ------------------------ |
| `GET`    | `/api/events`            | Get all events           |
| `GET`    | `/api/events/upcoming`   | Get upcoming events      |
| `GET`    | `/api/events/{id}`       | Get specific event       |
| `POST`   | `/api/events`            | Create new event         |
| `PUT`    | `/api/events/{id}`       | Update event             |
| `DELETE` | `/api/events/{id}`       | Delete event             |
| `GET`    | `/api/events/date-range` | Get events by date range |

## 📝 Event Schema

Each event contains:

- **Title** - Event name (max 200 chars)
- **Description** - Event details (max 1000 chars)
- **StartTime** / **EndTime** - Event schedule
- **LocationId** - Reference to location (string)
- **RoomId** - Reference to room (int)
- **TrainerId** - Reference to trainer (string)

### Example Request Body

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

## 🚫 Double Booking Prevention

The system automatically prevents double bookings by:

- Checking for time overlaps using LocationId and RoomId
- Returning HTTP 409 Conflict when conflicts are detected
- Excluding the current event when updating (allows extending/modifying existing events)

### Conflict Rules

- ✅ **Allowed**: Different rooms, same time
- ✅ **Allowed**: Same room, different times (no overlap)
- ❌ **Blocked**: Same room (RoomId), overlapping times

## 🗄️ Database

- Uses SQLite with Entity Framework Core
- Database file is auto-created as `EventService.db`
- Run `dotnet ef database update` from the Presentation folder if needed

## 🏗️ Project Structure

```
EventService/
├── Application/      # Business logic and DTOs
├── Persistence/      # Database entities and repositories
└── Presentation/     # Web API controllers
```
