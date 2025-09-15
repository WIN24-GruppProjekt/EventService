<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Event
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    [StringLength(200)]
    public string Location { get; set; } = string.Empty;

    [Required]
    [Range(1, 1000)]
    public int MaxParticipants { get; set; }

    public int AvailableSpots { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    // Foreign Keys
    public int InstructorId { get; set; }
    public int? CategoryId { get; set; }

    // Navigation properties
    public virtual Instructor Instructor { get; set; } = null!;
    public virtual Category? Category { get; set; }

    // Legacy property for backward compatibility
    public string InstructorName => Instructor?.FullName ?? string.Empty;
=======
public class Event
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string InstructorName { get; set; }
    public int MaxParticipants { get; set; }
    public int AvailableSpots { get; set; }
    public string Location { get; set; }
>>>>>>> 5aa8d78353f8a5339c412713a0ce22a6b5cedeb3
}
