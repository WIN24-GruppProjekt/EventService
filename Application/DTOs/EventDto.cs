namespace Application.DTOs;

public class EventDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string LocationId { get; set; } = null!;
    public int RoomId { get; set; }
    public string TrainerId { get; set; } = null!;
}
