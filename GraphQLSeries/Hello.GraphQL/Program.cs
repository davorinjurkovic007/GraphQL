using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using System;
using System.Threading.Tasks;

namespace Hello.GraphQL
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            var schemaFirst = Schema.For(@"
                type Query {
                    hello : String
                    }
                ");

            var schemaFirstJson = await schemaFirst.ExecuteAsync(_ =>
            {
                _.Query = "{ hello }";
                _.Root = new { Hello = "World" };
            });

            Console.WriteLine("Schema First: "+schemaFirstJson);

            /* Code first approach */
            var codeFirst = new Schema { Query = new HelloworldQuery() };

            var codeFirstJson = await codeFirst.ExecuteAsync(_ =>
            {
                _.Query = "{" +
                "   howdy" +
                "   hello" +
                "   test" +
                "}";
            });

            var secondCodeFirstJson = await codeFirst.ExecuteAsync(_ =>
            {
                _.Query = "{test}";
            });

            Console.WriteLine("Code first: " + codeFirstJson);

            Console.WriteLine("This is second test: " + secondCodeFirstJson);

        }
    }
}
