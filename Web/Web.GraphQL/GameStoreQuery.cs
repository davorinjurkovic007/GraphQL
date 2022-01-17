using GraphQL;
using GraphQL.Types;

namespace Web.GraphQL
{
    public class GameStoreQuery : ObjectGraphType
    {
        public GameStoreQuery()
        {
            Field<StringGraphType>(
                name: "name",
                resolve: context => "Steam"
             );

            Field<StringGraphType>(
                name:"grownUp",
                resolve: context => "Groviing up"
                );

            Field<ItemType>(
                "item",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "tag" }),
                resolve: context =>
                {
                    var tag = context.GetArgument<string>("tag");
                    return new DataSource().GetItemByTag(tag);
                });
        }
    }
}
