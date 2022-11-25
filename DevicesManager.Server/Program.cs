using DevicesManager.Persistence;
using DevicesManager.Server.Configuration;
using DevicesManager.Server.SignalR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DeviceManagerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddSignalR();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterSieveDependencies(builder.Configuration);
builder.Services.RegisterIoDependencies();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapHub<DevicesHub>("/devicesHub");
app.Run();
