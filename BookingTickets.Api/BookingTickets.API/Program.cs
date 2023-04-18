using System.Text;
using BookingTickets.API;
using BookingTickets.API.Options;
using BookingTickets.BLL;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.NewFolder;
using BookingTickets.BLL.Roles;
using BookingTickets.DAL;
using BookingTickets.DAL.Configuration;
using BookingTickets.DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IMainAdmin, MainAdmin>();
builder.Services.AddScoped<IClient, Client>();
builder.Services.AddScoped<IAdmin, Admin>();


builder.Services.AddAutoMapper(typeof(MapperApiProfile), typeof(MapperBLL));

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

void InjectSettingsConfiguration(WebApplicationBuilder builder)
{

    var authRepositorySection = builder.Configuration.GetSection("AuthRepositorySettings")
        .Get<AuthRepositorySettings>();

    builder.Services.AddSingleton<IAuthRepositorySettings>(authRepositorySection);
}

void InjectAuthenticationDependencies(WebApplicationBuilder builder)
{
    var jwtConfig = builder.Configuration.GetSection("JwtSettings")
        .Get<JwtConfigurationSettings>();

    builder.Services.AddSingleton<IJwtConfigurationSettings>(jwtConfig);

    builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(
            jwtConfig.Key);

        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),

            // Just to avoid issues on localhost, it must be true on prod
            ValidateIssuer = false,
            ValidateAudience = false,

            // To avoid re-generation scenario just for develop
            RequireExpirationTime = false,

            ValidateLifetime = true
        };
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("MainAdmin", policy =>
                          policy.RequireClaim("MainAdmin"));


    });

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddEntityFrameworkStores<AuthContext>();
}