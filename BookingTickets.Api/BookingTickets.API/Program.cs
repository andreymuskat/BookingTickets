using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using BookingTickets.API;
using BookingTickets.API.Options;
using BookingTickets.BLL;
using BookingTickets.BLL.Authentication;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.NewFolder;
using BookingTickets.BLL.Roles;
using BookingTickets.BLL.Statistics;
using BookingTickets.DAL;
using BookingTickets.DAL.Configuration;
using BookingTickets.DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Context>();
builder.Services.AddSingleton<Context>();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IFilmManager, FilmManager>();

builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
builder.Services.AddScoped<ICinemaManager, CinemaManager>();

builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ISessionManager, SessionManager>();

builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<ISeatManager, SeatManager>();

builder.Services.AddScoped<IHallRepository, HallRepository>();
builder.Services.AddScoped<IHallManager, HallManager>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddScoped<IStatisticsFilm, StatisticsFilm>();

builder.Services.AddScoped<IMainAdmin, MainAdmin>();
builder.Services.AddScoped<IClient, Client>();
builder.Services.AddScoped<IAdmin, Admin>();
builder.Services.AddScoped<IСashier, Cashier>();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAutoMapper(typeof(MapperApiProfile), typeof(MapperBLL));

InjectSettingsConfiguration(builder);
InjectAuthenticationDependencies(builder);
StartCheck(builder);


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
        options.AddPolicy("MainAdmin", builder =>
        {
            builder.RequireAssertion(k => k.User.HasClaim(ClaimTypes.Role, "MainAdmin"));
        });

        options.AddPolicy("Admin", builder =>
        {
            builder.RequireAssertion(k => k.User.HasClaim(ClaimTypes.Role, "MainAdmin")
                                        || k.User.HasClaim(ClaimTypes.Role, "Admin"));
        });

        options.AddPolicy("Cashier", builder =>
        {
            builder.RequireAssertion(k => k.User.HasClaim(ClaimTypes.Role, "MainAdmin")
                                        || k.User.HasClaim(ClaimTypes.Role, "Admin")
                                            || k.User.HasClaim(ClaimTypes.Role, "Cashier"));
        });

        options.AddPolicy("User", builder =>
        {
            builder.RequireAssertion(k => k.User.HasClaim(ClaimTypes.Role, "MainAdmin")
                                        || k.User.HasClaim(ClaimTypes.Role, "Admin")
                                            || k.User.HasClaim(ClaimTypes.Role, "Cashier")
                                                || k.User.HasClaim(ClaimTypes.Role, "Client"));
        });
    });

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddEntityFrameworkStores<Context>();

    builder.Services
    .AddControllersWithViews() 
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
}

async Task StartCheck(WebApplicationBuilder builder)
{
    OrderRepository orderRepository = new OrderRepository();

    while (true)
    {
        orderRepository.CheckOrderStatusAsync();

        await Task.Delay(60 * 1000);
    }
}