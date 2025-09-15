using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
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

    [Required(ErrorMessage = "Instructor name is required")]
    [StringLength(50, ErrorMessage = "Instructor name can be max 50 characters")]
    public string InstructorName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Max participants is required")]
    [Range(1, 100, ErrorMessage = "Max participants must be between 1 and 100")]
    public int MaxParticipants { get; set; }

    [Required(ErrorMessage = "Location is required")]
    [StringLength(100, ErrorMessage = "Location can be max 100 characters")]
=======
namespace Application.DTOs;

public class CreateEventDto
{
    [Required(ErrorMessage = "Titel är obligatorisk")]
    [StringLength(100, ErrorMessage = "Titel kan max vara 100 tecken")]
    public string Title { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Beskrivning kan max vara 500 tecken")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Starttid är obligatorisk")]
    public DateTime StartTime { get; set; }

    [Required(ErrorMessage = "Sluttid är obligatorisk")]
    public DateTime EndTime { get; set; }

    [Required(ErrorMessage = "Instruktörsnamn är obligatoriskt")]
    [StringLength(50, ErrorMessage = "Instruktörsnamn kan max vara 50 tecken")]
    public string InstructorName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Max antal deltagare är obligatoriskt")]
    [Range(1, 100, ErrorMessage = "Max antal deltagare måste vara mellan 1 och 100")]
    public int MaxParticipants { get; set; }

    [Required(ErrorMessage = "Plats är obligatorisk")]
    [StringLength(100, ErrorMessage = "Plats kan max vara 100 tecken")]
>>>>>>> 5aa8d78353f8a5339c412713a0ce22a6b5cedeb3
    public string Location { get; set; } = string.Empty;
}
