using Market.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Market.Infrastructure.Database;
using Market.Infrastructure.Mapper;
using Market.Infrastructure.Repositories.MarketRepository;

using Market.Services.MarketService;
using Market.Shared.Constants;
using Market.Services.ApplicationUserService;
using Market.Infrastructure.Repositories.ApplicationUserRepository;
using Market.API.Services;
using Microsoft.AspNetCore.Identity;
using Market.Core.Entities.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var connectionString = builder.Configuration.GetConnectionString(ConfigurationValues.ConnectionString);
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddAutoMapper(typeof(Program), typeof(Profiles));

#region Services

builder.Services.AddScoped<IMarketService, MarketService>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserSevice>();
builder.Services.AddScoped<IAccessManager, AccessManager>();
builder.Services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));

#endregion Services

#region Repositories

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMarketRepository, MarketRepository>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

#endregion Repositories

#region oauth_jwt

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection(ConfigurationValues.TokenKey).Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
.AddEntityFrameworkStores<DatabaseContext>()
.AddDefaultTokenProviders();

#endregion oauth_jwt

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseStaticFiles();

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
    .AllowCredentials()); // allow credentials
app.UseAuthorization();

app.MapControllers();
using var scope = app.Services.CreateScope();

var ctx = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
DatabaseContextSeedDevelopment.Initialize(ctx);
app.Run();