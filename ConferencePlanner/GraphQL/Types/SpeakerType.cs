using GraphQL.Data;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Types
{
    public class SpeakerType : ObjectType<Speaker>
    {
        /// <summary>
        /// In the type configuration we are giving SessionSpeakers a new name sessions. 
        /// Also, we are binding a new resolver to this field which also rewrites the result type. 
        /// The new field sessions now returns [Session].
        /// </summary>
        /// <param name="descriptor"></param>
        protected override void Configure(IObjectTypeDescriptor<Speaker> descriptor)
        {
            descriptor
                .Field(t => t.SessionSpeakers)
                .ResolveWith<SpeakerResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("sessions");
        }

        /// <summary>
        /// Error:
        /// https://github.com/ChilliCream/graphql-workshop/issues/82
        /// </summary>
        private class SpeakerResolvers
        {
            public async Task<IEnumerable<Session>> GetSessionsAsync(
                [Parent]Speaker speaker,
                [ScopedService] ApplicationDbContext dbContext, 
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                int[] sessionIds = await dbContext.Speakers
                    .Where(s => s.Id == speaker.Id)
                    .Include(s => s.SessionSpeakers)
                    .SelectMany(s => s.SessionSpeakers.Select(t => t.SessionId))
                    .ToArrayAsync();

                return await sessionById.LoadAsync(sessionIds, cancellationToken);
            }
        }
    }
}
