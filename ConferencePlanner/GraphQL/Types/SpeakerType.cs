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
            ///Error which I solve
            ///See if keep this way
            /////https://stackoverflow.com/questions/64226770/error-the-id-1-has-an-invalid-format-when-querying-hotchocolate
            ///https://stackoverflow.com/questions/65747359/running-graphql-query-returns-the-id-1-has-an-invalid-format
            ///The whole idea behind this is that we can use Id, in the safe way in cache. 
            //descriptor
            //.Field(f => f.Id).ID(nameof(Speaker));

            /// For explaining this part
            /// https://chillicream.com/docs/hotchocolate/defining-a-schema/relay
            /// https://relay.dev/docs/guides/graphql-server-specification/
            /// https://graphql.org/learn/global-object-identification/
            descriptor
               .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode(async (ctx, id) => await ctx.DataLoader<SpeakerByIdDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));

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
