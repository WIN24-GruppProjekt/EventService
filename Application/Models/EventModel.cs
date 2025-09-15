namespace Application.Models;

public class EventModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Location { get; set; } = string.Empty;
    public int MaxParticipants { get; set; }
    public int AvailableSpots { get; set; }
    public bool IsActive { get; set; }

    // Business logic properties
    public bool IsFull => AvailableSpots <= 0;
    public bool IsUpcoming => StartTime > DateTime.UtcNow;
    public string Duration => $"{(EndTime - StartTime).TotalMinutes} min";

    // Related data
    public string? CategoryName { get; set; }
}
