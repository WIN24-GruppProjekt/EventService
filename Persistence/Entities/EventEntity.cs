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

    [Required(ErrorMessage = "Location is required")]
    public string Location { get; set; } = null!;

    [Required(ErrorMessage = "Location room is required")]
    public string LocationRoom { get; set; } = null!;

    [Required(ErrorMessage = "Trainer name is required")]
    public string TrainerName { get; set; } = null!;
}
