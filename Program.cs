using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tanger_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string connectionString = builder.Configuration.GetConnectionString(name: "Default");

builder.Services.AddDbContext<Tanger_APIDbContext>(options => options.UseSqlServer(connectionString));
//Install-Package Microsoft.EntityFrameworkCore.SqlServer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
