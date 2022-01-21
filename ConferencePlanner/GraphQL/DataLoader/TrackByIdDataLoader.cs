using GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DataLoader
{
    public class TrackByIdDataLoader : BatchDataLoader<int, Track>
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public TrackByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<ApplicationDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            this.dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }
        protected override async Task<IReadOnlyDictionary<int, Track>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext = dbContextFactory.CreateDbContext();

            return await dbContext
                .Tracks
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
