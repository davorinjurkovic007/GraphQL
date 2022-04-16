// See https://aka.ms/new-console-template for more information
using Demo1.GraphQL;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

Console.WriteLine("Hello, World!");

var serviceCollection = new ServiceCollection();

serviceCollection
    .AddStarWarsSwapi()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://swapi-graphql.netlify.app/.netlify/functions/index"));

IServiceProvider services = serviceCollection.BuildServiceProvider();

IStarWarsSwapi client = services.GetRequiredService<IStarWarsSwapi>();

var result = await client.AllFilms.ExecuteAsync("ZmlsbXM6MQ==");
result.EnsureNoErrors();

Console.WriteLine($"The movie is: {result.Data.Film.Title}");

Console.ReadKey();




