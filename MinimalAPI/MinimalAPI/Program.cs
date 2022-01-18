using MinimalAPI.Queries;
/// <summary>
/// https://dotnetthoughts.net/getting-started-with-graphql-aspnetcore/
/// </summary>
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<Query>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


app.Run();
