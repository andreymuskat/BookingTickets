using BookingTickets.API;
using BookingTickets.BLL;
using BookingTickets.BLL.NewFolder;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IMainAdmin, MainAdmin>();

builder.Services.AddAutoMapper(typeof(MapperAPI), typeof(MapperBLL));

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
