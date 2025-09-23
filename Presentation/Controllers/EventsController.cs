using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetAllEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("upcoming")]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetUpcomingEvents()
    {
        var events = await _eventService.GetUpcomingEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventDto>> GetEvent(Guid id)
    {
        var eventDto = await _eventService.GetEventByIdAsync(id);
        if (eventDto == null)
        {
            return NotFound();
        }

        return Ok(eventDto);
    }

    [HttpPost]
    public async Task<ActionResult<EventDto>> CreateEvent(CreateEventDto createEventDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Check for conflicts before attempting to create
        var hasConflict = await _eventService.HasConflictAsync(
            createEventDto.StartTime,
            createEventDto.EndTime,
            createEventDto.Location,
            createEventDto.LocationRoom
        );

        if (hasConflict)
        {
            return Conflict(
                new
                {
                    message = "Event conflicts with an existing booking in the same location and room during the specified time.",
                }
            );
        }

        var eventDto = await _eventService.CreateEventAsync(createEventDto);
        if (eventDto == null)
        {
            return BadRequest("Failed to create event");
        }

        return CreatedAtAction(nameof(GetEvent), new { id = eventDto.Id }, eventDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EventDto>> UpdateEvent(Guid id, CreateEventDto updateEventDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Check for conflicts before attempting to update, excluding the current event
        var hasConflict = await _eventService.HasConflictAsync(
            updateEventDto.StartTime,
            updateEventDto.EndTime,
            updateEventDto.Location,
            updateEventDto.LocationRoom,
            id
        );

        if (hasConflict)
        {
            return Conflict(
                new
                {
                    message = "Event conflicts with an existing booking in the same location and room during the specified time.",
                }
            );
        }

        var eventDto = await _eventService.UpdateEventAsync(id, updateEventDto);
        if (eventDto == null)
        {
            return NotFound();
        }

        return Ok(eventDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEvent(Guid id)
    {
        var result = await _eventService.DeleteEventAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("date-range")]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsByDateRange(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate
    )
    {
        var events = await _eventService.GetEventsByDateRangeAsync(startDate, endDate);
        return Ok(events);
    }
}
