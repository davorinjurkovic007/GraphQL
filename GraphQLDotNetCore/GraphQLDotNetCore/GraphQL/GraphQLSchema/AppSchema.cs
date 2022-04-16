using GraphQL.Types;
using GraphQLDotNetCore.GraphQL.GraphQLQueries;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQLDotNetCore.GraphQL.GraphQLSchema
{
    public class AppSchema :Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
        }
    }
}
