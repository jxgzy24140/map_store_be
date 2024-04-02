using map_project.Models;
using map_project.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MapStoreDatabase"));

builder.Services.AddTransient<IMapService, MapService>();
builder.Services.AddTransient<ISettingService, SettingService>();
builder.Services.AddTransient<IEventService, EventService>();

builder.Services.AddCors(x => x.AddDefaultPolicy(y => y.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
