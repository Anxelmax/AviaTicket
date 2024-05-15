using AviaTicket.DataAccess.Contexts;
using AviaTicket.DataAccess.Repositories;
using AviaTicket.Middlewares;
using AviaTicket.Service.Mappers;
using AviaTicket.Service.Services.Airplanes;
using AviaTicket.Service.Services.Races;
using AviaTicket.Service.Services.Seats;
using AviaTicket.Service.Services.Tickets;
using AviaTicket.Service.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAirplane, AirplaneService>();
builder.Services.AddScoped<IRace, RaceService>();
builder.Services.AddScoped<ISeat, SeatService>();
builder.Services.AddScoped<ITicket, TicketService>();
builder.Services.AddScoped<IUser, UserService>();

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

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();
