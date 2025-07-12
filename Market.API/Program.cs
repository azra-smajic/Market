using Market.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Market.Infrastructure.Database;
using Market.Infrastructure.Mapper;
using Market.Infrastructure.Repositories.MarketRepository;

using Market.Services.MarketService;
using Market.Shared.Constants;
using Market.Services.ApplicationUserService;
using Market.Infrastructure.Repositories.ApplicationUserRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var connectionString = builder.Configuration.GetConnectionString(ConfigurationValues.ConnectionString);
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program), typeof(Profiles));

#region Services

builder.Services.AddScoped<IMarketService, MarketService>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserSevice>();

#endregion Services

#region Repositories

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMarketRepository, MarketRepository>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

#endregion Repositories

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
using var scope = app.Services.CreateScope();

var ctx = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
DatabaseContextSeedDevelopment.Initialize(ctx);
app.Run();