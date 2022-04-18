using CommandGQLNet6.Data;
using CommandGQLNet6.GraphQL.Platforms;
using CommandGQLNet6.Models;

namespace CommandGQLNet6.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, [ScopedService] AppDbContext context)
        {
            var platform = new Platform
            {
                Name = input.Name
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync();

            return new AddPlatformPayload(platform);
        }
    }
}
