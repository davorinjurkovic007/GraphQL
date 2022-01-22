using GraphQL.Data;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Sessions
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class SessionQueries
    {
        [UseApplicationDbContext]
        public async Task<IEnumerable<Session>> GetSessionsAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.Sessions.ToListAsync(cancellationToken);

        public Task<Session> GetSessionByIdAsync(
            [ID(nameof(Session))] int id,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken) =>
            sessionById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Session>> GetSessionsByIdAsync(
            [ID(nameof(Session))] int[] ids,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken) =>
            await sessionById.LoadAsync(ids, cancellationToken);
    }
}
