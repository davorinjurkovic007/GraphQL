using GraphQL;
using GraphQL.Data;
using GraphQL.Mutations;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// https://github.com/ChilliCream/graphql-workshop
/// </summary>
/// 
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ConectionString");

/// <summary>
/// By default the DBContext pool will keep 128 DBContext instances in its pool.
/// </summary>
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

var app = builder.Build();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

if (environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endPoints =>
{
    endPoints.MapGraphQL();
});

app.Run();
