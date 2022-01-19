using GraphQL.Data;
using GraphQL.Extensions;

namespace GraphQL.Mutations
{
    public class Mutation
    {
        /// <summary>
        /// By annotating UseApplicationDbContext we are essentially applying a Middleware to the field resolver pipeline. 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input, [ScopedService] ApplicationDbContext context)
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }
    }
}
