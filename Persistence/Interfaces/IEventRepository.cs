using Persistence.Entities;
using Persistence.Models;

namespace Persistence.Interfaces;

public interface IEventRepository : IBaseRepository<EventEntity>
{
    Task<RepositoryResult<IEnumerable<EventEntity>>> GetUpcomingEventsAsync();
    Task<RepositoryResult<IEnumerable<EventEntity>>> GetEventsByDateRangeAsync(
        DateTime startDate,
        DateTime endDate
    );
}
