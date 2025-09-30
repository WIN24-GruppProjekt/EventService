using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class CreateEventDto
{
    [Required]
    [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters.")]
    public string Title { get; set; } = null!;

    [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Location ID cannot be longer than 100 characters.")]
    public string LocationId { get; set; } = null!;

    [Required]
    public int RoomId { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Trainer ID cannot be longer than 100 characters.")]
    public string TrainerId { get; set; } = null!;
}
