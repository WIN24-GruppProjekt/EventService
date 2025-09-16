using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class CreateEventDto
{
    [Required]
    [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "Location cannot be longer than 200 characters.")]
    public string Location { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Location room cannot be longer than 100 characters.")]
    public string LocationRoom { get; set; } = string.Empty;
}
