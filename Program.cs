using Microsoft.OpenApi.Models;
using RapidApi_Weather.Interface;
using RapidApi_Weather.Logic;
using System.Net;
using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather API", Version = "v1" });

//    var security = new Dictionary<string, IEnumerable<string>>
//                {
//                    { "Bearer", new string[0] }
//                };

//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description = "JWT Authorization header using the Bearer scheme."
//    });
//c.AddSecurityRequirement(new OpenApiSecurityRequirement{
//    {
//        new OpenApiSecurityScheme
//    {
//        Reference = new OpenApiReference
//    {
//        Type = ReferenceType.SecurityScheme,
//        Id = "Bearer"
//    }
//    },
//        new string[] {}
//    }
//    });
});

//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<IWeatherForecast, WeatherForecast>();



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
