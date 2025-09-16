using Application.DTOs;

namespace Application.Interfaces;

public interface IEventService
{
    Task<IEnumerable<EventDto>> GetAllEventsAsync();
    Task<IEnumerable<EventDto>> GetUpcomingEventsAsync();
    Task<EventDto?> GetEventByIdAsync(Guid id);
    Task<EventDto?> CreateEventAsync(CreateEventDto createEventDto);
    Task<EventDto?> UpdateEventAsync(Guid id, CreateEventDto updateEventDto);
    Task<bool> DeleteEventAsync(Guid id);
    Task<IEnumerable<EventDto>> GetEventsByDateRangeAsync(DateTime startDate, DateTime endDate);
}
