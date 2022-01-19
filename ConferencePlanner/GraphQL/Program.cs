using GraphQL;
using GraphQL.Data;
using GraphQL.DataLoader;
using GraphQL.Mutations;
using GraphQL.Types;
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
                .AddMutationType<Mutation>()
                .AddType<SpeakerType>()
                .AddDataLoader<SpeakerByIdDataLoader>()
                .AddDataLoader<SessionByIdDataLoader>();

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
    endPoints.MapGraphQL("/graf");
});

app.Run();
