# EventService - Gym Booking System

A clean architecture .NET 9.0 API for managing gym events and bookings.

## 🏗️ Architecture

- **Presentation Layer** - ASP.NET Core Web API
- **Application Layer** - Business logic and DTOs
- **Persistence Layer** - Entity Framework Core with SQLite

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK
- Your favorite IDE (Rider, Visual Studio, VS Code)

### Setup

1. **Clone the repository**

   ```bash
   git clone <your-repo-url>
   cd EventService
   ```

2. **Configure settings**

   ```bash
   # Copy template files
   cp Presentation/appsettings.template.json Presentation/appsettings.json
   cp Presentation/appsettings.Development.template.json Presentation/appsettings.Development.json
   ```

3. **Restore packages**

   ```bash
   dotnet restore
   ```

4. **Run migrations**

   ```bash
   cd Presentation
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run --urls="http://localhost:5001"
   ```

## 📚 API Endpoints

### Events

- `GET /api/events` - Get all events
- `GET /api/events/upcoming` - Get upcoming events
- `GET /api/events/{id}` - Get specific event
- `POST /api/events` - Create new event
- `PUT /api/events/{id}` - Update event
- `DELETE /api/events/{id}` - Delete event
- `GET /api/events/date-range` - Get events by date range

### Swagger Documentation

- Available at: `http://localhost:5001/swagger`

## 🗄️ Database

- **Type**: SQLite
- **File**: `EventService.db` (auto-created)
- **Migrations**: Located in `Presentation/Migrations/`

### Sample Data

The database includes 10 sample gym events covering various workout types.

## 🔧 Configuration

Configuration files are ignored by Git for security. Use the template files:

- `appsettings.template.json` - Production template
- `appsettings.Development.template.json` - Development template

## 🏃‍♂️ Frontend Integration

The API includes CORS configuration for frontend connections:

- Allowed origins: `http://localhost:3000`, `http://localhost:5001`

## 🛠️ Development

### Project Structure

```
EventService/
├── Application/           # Business logic
│   ├── DTOs/             # Data Transfer Objects
│   ├── Interfaces/       # Service contracts
│   └── Services/         # Business logic implementation
├── Persistence/          # Data access
│   ├── Contexts/         # EF Core DbContext
│   ├── Entities/         # Database entities
│   ├── Interfaces/       # Repository contracts
│   ├── Models/           # Helper models
│   └── Repositories/     # Data access implementation
└── Presentation/         # Web API
    ├── Controllers/      # API controllers
    ├── Migrations/       # EF Core migrations
    └── Properties/       # Launch settings
```

### Adding New Migrations

```bash
cd Presentation
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

## 🔐 Security Notes

- Database files (`*.db`) are ignored by Git
- Configuration files with sensitive data are ignored
- GUIDs are used for entity IDs for security and uniqueness

## 📝 License

This project is for educational purposes as part of a group project assignment.
