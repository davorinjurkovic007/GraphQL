using GraphQL.Types;

namespace GraphQLAzureDemo.Notes
{
    public class NotesSchema : Schema
    {
        public NotesSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<NotesQuery>();
        }
    }
}
