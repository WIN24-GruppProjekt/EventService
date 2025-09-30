using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class EventEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Start time is required")]
    public DateTime StartTime { get; set; }

    [Required(ErrorMessage = "End time is required")]
    public DateTime EndTime { get; set; }

    [Required(ErrorMessage = "Location ID is required")]
    public string LocationId { get; set; } = null!;

    [Required(ErrorMessage = "Room ID is required")]
    public int RoomId { get; set; }

    [Required(ErrorMessage = "Trainer ID is required")]
    public string TrainerId { get; set; } = null!;
}
