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
        }
    }
}
