using CarvedRock.Api.Data;
using CarvedRock.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CarvedRockDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarvedRock"));
});
builder.Services.AddScoped<ProductRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
