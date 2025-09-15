using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class UpdateEventDto
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title can be max 200 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Description can be max 1000 characters")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Start time is required")]
    public DateTime StartTime { get; set; }

    [Required(ErrorMessage = "End time is required")]
    public DateTime EndTime { get; set; }

    [Required(ErrorMessage = "Location is required")]
    [StringLength(200, ErrorMessage = "Location can be max 200 characters")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Max participants is required")]
    [Range(1, 1000, ErrorMessage = "Max participants must be between 1 and 1000")]
    public int MaxParticipants { get; set; }

    // Foreign Keys for relationships
    [Required(ErrorMessage = "Instructor is required")]
    public int InstructorId { get; set; }

    public int? CategoryId { get; set; }

    // Custom validation
    public bool IsValidTimeRange => EndTime > StartTime;
}
