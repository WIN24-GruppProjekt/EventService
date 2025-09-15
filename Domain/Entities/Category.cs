using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty; // Yoga, CrossFit, Spinning, etc.

    [StringLength(500)]
    public string? Description { get; set; }

    [StringLength(50)]
    public string? Color { get; set; } // Hex color for UI display

    [StringLength(100)]
    public string? Icon { get; set; } // Font Awesome icon class or image URL

    public bool IsActive { get; set; } = true;

    public int SortOrder { get; set; } = 0; // For custom ordering in UI

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public virtual ICollection<Event> Events { get; set; } = [];
}
