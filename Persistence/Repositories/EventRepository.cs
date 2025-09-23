using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Interfaces;
using Persistence.Models;

namespace Persistence.Repositories;

public class EventRepository : BaseRepository<EventEntity>, IEventRepository
{
    public EventRepository(DataContext context)
        : base(context) { }

    public async Task<RepositoryResult<IEnumerable<EventEntity>>> GetUpcomingEventsAsync()
    {
        try
        {
            var upcomingEvents = await _dbSet
                .Where(e => e.StartTime > DateTime.UtcNow)
                .OrderBy(e => e.StartTime)
                .ToListAsync();

            return RepositoryResult<IEnumerable<EventEntity>>.Success(upcomingEvents);
        }
        catch (Exception ex)
        {
            return RepositoryResult<IEnumerable<EventEntity>>.Failure(
                $"Error retrieving upcoming events: {ex.Message}"
            );
        }
    }

    public async Task<RepositoryResult<IEnumerable<EventEntity>>> GetEventsByDateRangeAsync(
        DateTime startDate,
        DateTime endDate
    )
    {
        try
        {
            var events = await _dbSet
                .Where(e => e.StartTime >= startDate && e.EndTime <= endDate)
                .OrderBy(e => e.StartTime)
                .ToListAsync();

            return RepositoryResult<IEnumerable<EventEntity>>.Success(events);
        }
        catch (Exception ex)
        {
            return RepositoryResult<IEnumerable<EventEntity>>.Failure(
                $"Error retrieving events by date range: {ex.Message}"
            );
        }
    }

    public async Task<RepositoryResult<IEnumerable<EventEntity>>> GetConflictingEventsAsync(
        DateTime startTime,
        DateTime endTime,
        string location,
        string locationRoom,
        Guid? excludeEventId = null
    )
    {
        try
        {
            var query = _dbSet
                .Where(e => e.Location == location && e.LocationRoom == locationRoom)
                .Where(e => e.StartTime < endTime && e.EndTime > startTime); // Overlap condition

            if (excludeEventId.HasValue)
            {
                query = query.Where(e => e.Id != excludeEventId.Value);
            }

            var conflictingEvents = await query.ToListAsync();

            return RepositoryResult<IEnumerable<EventEntity>>.Success(conflictingEvents);
        }
        catch (Exception ex)
        {
            return RepositoryResult<IEnumerable<EventEntity>>.Failure(
                $"Error checking for conflicting events: {ex.Message}"
            );
        }
    }
}
