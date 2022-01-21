using GraphQL.Data;
using GraphQL.Extensions;

namespace GraphQL.Tracks
{
    [ExtendObjectType("Mutation")]
    public class TracksMutations
    {
        [UseApplicationDbContext]
        public async Task<AddTrackPayload> AddTrackAsync(
            AddTrackInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var track = new Track { Name = input.Name };
            context.Tracks.Add(track);

            await context.SaveChangesAsync(cancellationToken);

            return new AddTrackPayload(track);
        }
    }
}
