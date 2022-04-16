// See https://aka.ms/new-console-template for more information
using Demo.GraphQL;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

Console.WriteLine("Hello, World!");

var serviceCollection = new ServiceCollection();

serviceCollection
    .AddConferenceClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://workshop.chillicream.com/graphql"));

IServiceProvider services = serviceCollection.BuildServiceProvider();

IConferenceClient client = services.GetRequiredService<IConferenceClient>();

var result = await client.GetSessions.ExecuteAsync();
result.EnsureNoErrors();

foreach (var session in result.Data.Sessions.Nodes)
{
    Console.WriteLine(session.Title);
}

Console.WriteLine("------------------------------------------------------------------------------------");
Console.WriteLine("New call");
Console.WriteLine("-------------------------------------------------------------------------------------");

var newResult = await client.GetAttendees.ExecuteAsync();
newResult.EnsureNoErrors();

foreach(var attendees in newResult.Data.Attendees.Nodes)
{
    Console.WriteLine(attendees.FirstName);
}


Console.ReadKey();
