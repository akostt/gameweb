using GameWeb.Application;
using GameWeb.Logic.Stores;
using GameWeb.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//Add services to the container

builder.Services.AddControllers();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserStore, UserRepository>();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext))));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSwagger();
app.MapControllers();

app.Run();