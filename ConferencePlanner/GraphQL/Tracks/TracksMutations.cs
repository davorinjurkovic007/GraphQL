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

        [UseApplicationDbContext]
        public async Task<RenameTrackPayload> ReanmeTrackAsync(
            RenameTrackInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancelToken)
        {
            Track? track = await context.Tracks.FindAsync(input.Id);

            if (track is null)
            {
                throw new GraphQLException("Track not found.");
            }

            track.Name = input.Name;

            await context.SaveChangesAsync(cancelToken);

            return new RenameTrackPayload(track);
        }
    }
}
