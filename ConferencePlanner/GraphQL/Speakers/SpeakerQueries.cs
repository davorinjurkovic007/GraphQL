using GraphQL.Data;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class SpeakerQueries
    {
        
        /// <summary>
        /// By annotating UseApplicationDbContext we are essentially applying a Middleware to the field resolver pipeline. 
        /// Important: Note, that we no longer are returning the IQueryable but are executing the IQueryable by using ToListAsync.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
            context.Speakers.ToListAsync();

        /// <summary>
        /// Wherever we handle id values we need to annotate them with the ID attribute in order to tell the execution 
        /// engine what kind of ID this is. We also can do that in the fluent API by using the ID descriptor method a
        /// field or argument descriptor.
        /// descriptor.Field(t => t.FooId).ID("FOO");
        /// Error
        /// https://stackoverflow.com/questions/64226770/error-the-id-1-has-an-invalid-format-when-querying-hotchocolate
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataLoader"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Speaker> GetSpeakerAsync(
            int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}
