using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello.GraphQL
{
    internal class HelloworldQuery : ObjectGraphType
    {
        public HelloworldQuery()
        {
            Field<StringGraphType>(
                name: "hello",
                resolve: context => "World"
                );

            Field<StringGraphType>(
                name: "test",
                resolve: context => "This is a test");

            Field<StringGraphType>(
                name: "howdy",
                resolve: context => "universe");
        }
    }
}
