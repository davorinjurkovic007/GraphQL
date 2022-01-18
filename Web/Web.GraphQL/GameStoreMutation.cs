using GraphQL;
using GraphQL.Types;
using Web.GraphQL.RepositoryFiles;

namespace Web.GraphQL
{
    public class GameStoreMutation : ObjectGraphType
    {
        public GameStoreMutation(IRepository repository)
        {
            FieldAsync<ItemType>(
                "createItem",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ItemInputType>> { Name = "item" }
            ),
            resolve: async context =>
            {
                var item = context.GetArgument<Item>("item");
                //return new DataSource().AddItem(item);
                return await repository.AddItem(item);
            });
        }
    }
}
