using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.GraphQL
{
    public class GraphQLMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IDocumentWriter writer;
        private readonly IDocumentExecuter executor;
        private readonly GraphQLOptions options;

        public GraphQLMiddleware(RequestDelegate next, IDocumentWriter writer, IDocumentExecuter executor, IOptions<GraphQLOptions> options)
        {
            this.next = next;
            this.writer = writer;
            this.executor = executor;
            this.options = options.Value;
        }

        public async Task InvokeAsync(HttpContext httpContext, ISchema schema)
        {
            if(httpContext.Request.Path.StartsWithSegments("/graphql") && string.Equals(httpContext.Request.Method, "POST", StringComparison.OrdinalIgnoreCase))
            {
                var request = await JsonSerializer
                    .DeserializeAsync<GraphQLRequest>(
                        httpContext.Request.Body,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                var result = await executor.ExecuteAsync( doc =>
                {
                    doc.Schema = schema;
                    doc.Query = request.Query;
                    doc.Inputs = request.Variables.ToInputs();
                }).ConfigureAwait(false);

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 200;

                await writer.WriteAsync(httpContext.Response.Body, result);
            }
            else
            {
                await next(httpContext);
            }
        }

    }
}
