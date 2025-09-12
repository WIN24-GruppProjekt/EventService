using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class UpdateEventDto
{
    [Required(ErrorMessage = "Id är obligatoriskt")]
    public int Id { get; set; }

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
    public string Location { get; set; } = string.Empty;
}