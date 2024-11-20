using LAB6.Models;
using LAB6.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using LAB6;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API V1", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "API V2", Version = "v2" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });


var databaseType = builder.Configuration["DatabaseType"];
switch (databaseType)
{
    case "SqlServer":
        builder.Services.AddDbContext<CarServiceContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
        break;
    case "PostgreSQL":
        builder.Services.AddDbContext<CarServiceContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));
        break;
    case "Sqlite":
        builder.Services.AddDbContext<CarServiceContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
        break;
    case "InMemory":
        builder.Services.AddDbContext<CarServiceContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));
        break;
}


// Add versioning configuration
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0); // Default to v1
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = "https://dev-jrjrqikuurp2nilh.us.auth0.com/";
    options.Audience = "https://dev-jrjrqikuurp2nilh.us.auth0.com/api/v2/";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "https://dev-jrjrqikuurp2nilh.us.auth0.com/",
        ValidateAudience = true,
        ValidAudience = "https://dev-jrjrqikuurp2nilh.us.auth0.com/api/v2/",
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ZliPXyyIKw7ykLpN102cDEGpFWXiaME7RZfCq0AXjpKeOk9FOd6XMVb9zQOhG7Nj")),
        ValidateIssuerSigningKey = true,
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy => policy.RequireClaim("scope", "read:messages"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddScoped<IMachine, MachineAuthService>();

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
