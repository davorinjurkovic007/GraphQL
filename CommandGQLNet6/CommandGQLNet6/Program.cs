using CommandGQLNet6.Data;
using CommandGQLNet6.GraphQL;
using CommandGQLNet6.GraphQL.Commands;
using CommandGQLNet6.GraphQL.Platforms;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandConnectionString")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions();
    /*.AddProjections()*/;

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseWebSockets();

app.UseRouting();

app.MapControllers();

app.MapGraphQL("/graphql");

app.UseGraphQLVoyager(new VoyagerOptions { GraphQLEndPoint = "/graphql" }, "/graphql-voyager");

app.Run();
