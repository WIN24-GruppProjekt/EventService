namespace Application.Models;

public class EventSearchModel
{
    public string? SearchTerm { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? CategoryId { get; set; }
    public int? InstructorId { get; set; }
    public string? Location { get; set; }
    public bool OnlyAvailable { get; set; } = false;
}
