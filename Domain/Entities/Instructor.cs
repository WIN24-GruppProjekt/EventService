using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Instructor
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [StringLength(500)]
    public string? Bio { get; set; }

    [StringLength(200)]
    public string? Specialties { get; set; } // Yoga, CrossFit, Spinning etc.

    public DateTime HiredDate { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public virtual ICollection<Event> Events { get; set; } = [];

    // Computed property for display name
    public string FullName => $"{FirstName} {LastName}";
}
