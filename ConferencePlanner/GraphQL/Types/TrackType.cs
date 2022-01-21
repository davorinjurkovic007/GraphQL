using GraphQL.Data;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Types
{
    public class TrackType : ObjectType<Track>
    {
        protected override void Configure(IObjectTypeDescriptor<Track> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode(async (ctx, id) => await ctx.DataLoader<TrackByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(t => t.Sessions)
                .ResolveWith<TrackResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("sessions");

        }

        private class TrackResolvers
        {
            public async Task<IEnumerable<Session>> GetSessionsAsync(
                Track track,
                [ScopedService] ApplicationDbContext dbContext,
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                int[] sessionIds = await dbContext.Sessions
                    .Where(s => s.Id == track.Id)
                    .Select(s => s.Id)
                    .ToArrayAsync();

                return await sessionById.LoadAsync(sessionIds, cancellationToken);
            }
        }
    }
}
