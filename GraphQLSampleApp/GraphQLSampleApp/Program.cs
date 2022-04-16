using GraphQLSampleApp.DataAccess;
using GraphQLSampleApp.DataAccess.DAO;
using GraphQLSampleApp.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SampleAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SampleAppDbContext")));

builder.Services.AddInMemorySubscriptions();
builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>();

builder.Services.AddScoped<EmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<DepartmentRepository, DepartmentRepository>();

builder.Services.AddCors(option => {
    option.AddPolicy("allowedOrigin",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("allowedOrigin");
app.UseWebSockets();
app
    .UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

//app.MapControllers();

app.Run();
