using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class CreateEventDto
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title can be max 100 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Description can be max 500 characters")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Start time is required")]
    public DateTime StartTime { get; set; }

    [Required(ErrorMessage = "End time is required")]
    public DateTime EndTime { get; set; }

    [Required(ErrorMessage = "Max participants is required")]
    [Range(1, 100, ErrorMessage = "Max participants must be between 1 and 100")]
    public int MaxParticipants { get; set; }

    [Required(ErrorMessage = "Location is required")]
    [StringLength(100, ErrorMessage = "Location can be max 100 characters")]
    public string Location { get; set; } = string.Empty;
}
