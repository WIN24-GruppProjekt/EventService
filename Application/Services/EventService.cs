using Application.DTOs;
using Application.Interfaces;
using Persistence.Entities;
using Persistence.Interfaces;

namespace Application.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
    {
        var result = await _eventRepository.GetAllAsync();
        if (!result.IsSuccess || result.Data == null)
        {
            return Enumerable.Empty<EventDto>();
        }

        return result.Data.Select(MapToDto);
    }

    public async Task<IEnumerable<EventDto>> GetUpcomingEventsAsync()
    {
        var result = await _eventRepository.GetUpcomingEventsAsync();
        if (!result.IsSuccess || result.Data == null)
        {
            return Enumerable.Empty<EventDto>();
        }

        return result.Data.Select(MapToDto);
    }

    public async Task<EventDto?> GetEventByIdAsync(Guid id)
    {
        var result = await _eventRepository.GetByIdAsync(id);
        return result.IsSuccess && result.Data != null ? MapToDto(result.Data) : null;
    }

    public async Task<EventDto?> CreateEventAsync(CreateEventDto createEventDto)
    {
        var eventEntity = new EventEntity
        {
            Title = createEventDto.Title,
            Description = createEventDto.Description,
            StartTime = createEventDto.StartTime,
            EndTime = createEventDto.EndTime,
            Location = createEventDto.Location,
            LocationRoom = createEventDto.LocationRoom,
        };

        var result = await _eventRepository.AddAsync(eventEntity);
        return result.IsSuccess && result.Data != null ? MapToDto(result.Data) : null;
    }

    public async Task<EventDto?> UpdateEventAsync(Guid id, CreateEventDto updateEventDto)
    {
        var existingResult = await _eventRepository.GetByIdAsync(id);
        if (!existingResult.IsSuccess || existingResult.Data == null)
        {
            return null;
        }

        var eventEntity = existingResult.Data;
        eventEntity.Title = updateEventDto.Title;
        eventEntity.Description = updateEventDto.Description;
        eventEntity.StartTime = updateEventDto.StartTime;
        eventEntity.EndTime = updateEventDto.EndTime;
        eventEntity.Location = updateEventDto.Location;
        eventEntity.LocationRoom = updateEventDto.LocationRoom;

        var result = await _eventRepository.UpdateAsync(eventEntity);
        return result.IsSuccess && result.Data != null ? MapToDto(result.Data) : null;
    }

    public async Task<bool> DeleteEventAsync(Guid id)
    {
        var result = await _eventRepository.DeleteAsync(id);
        return result.IsSuccess && result.Data == true;
    }

    public async Task<IEnumerable<EventDto>> GetEventsByDateRangeAsync(
        DateTime startDate,
        DateTime endDate
    )
    {
        var result = await _eventRepository.GetEventsByDateRangeAsync(startDate, endDate);
        if (!result.IsSuccess || result.Data == null)
        {
            return Enumerable.Empty<EventDto>();
        }

        return result.Data.Select(MapToDto);
    }

    private static EventDto MapToDto(EventEntity entity)
    {
        return new EventDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            StartTime = entity.StartTime,
            EndTime = entity.EndTime,
            Location = entity.Location,
            LocationRoom = entity.LocationRoom,
        };
    }
}
