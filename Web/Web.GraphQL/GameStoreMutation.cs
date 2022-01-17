using GraphQL;
using GraphQL.Types;

namespace Web.GraphQL
{
    public class GameStoreMutation : ObjectGraphType
    {
        public GameStoreMutation()
        {
            Field<ItemType>(
                "createItem",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ItemInputType>> { Name = "item" }
            ),
            resolve: context =>
            {
                var item = context.GetArgument<Item>("item");
                return new DataSource().AddItem(item);
            });
        }
    }
}
